using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SummoningManager : MonoBehaviour
{
    private struct Stack
    {
        public int number;
        public SpellData spell;

        public Stack(SpellData _spell)
        {
            spell = _spell;
            number = 1;
        }
    }
    [SerializeField] private Image m_spellIcon;
    [SerializeField] private ParticleSystem m_say;
    [SerializeField] private ParticleSystem m_summonersSay;
    [SerializeField] private Transform m_progressBar;
    [SerializeField] private TextMeshProUGUI m_progressText;
    [SerializeField] private List<Summoner> m_summoners;
    [SerializeField] private GameObject m_summonerPrefab;

    private List<Stack> m_spellsStack;

    private SpellData m_currentSpell;
    private int m_runesSayed = 0;
    public float circleSize => 10;
    public Vector2 circleCenter => transform.position + Vector3.up * 0.5f;

    public float progress => m_currentSpell && m_currentSpell.numberOfRunes > 0 ? m_runesSayed / (float)m_currentSpell.numberOfRunes : 0.0f;

    void Awake()
    {
        m_spellsStack = new List<Stack>();
        m_stackUI = new List<SpellStackUI>();
        UpdateProgressBar();
    }
    void OnEnable()
    {
        KeyboardReader.OnKeyPressed += KeyPressed;
    }
    
    void OnDisable()
    {
        KeyboardReader.OnKeyPressed -= KeyPressed;
    }

    private void KeyPressed(string _keyName)
    {
        if (!m_currentSpell) return;
        m_say.Emit(1);
        
        m_runesSayed += 1;
        UpdateProgressBar();
        if (m_currentSpell && m_runesSayed >= m_currentSpell.numberOfRunes)
        {
            StopSpell();
        }
    }

    public void SummonerKeyPressed()
    {
        if (!m_currentSpell) return;
        m_runesSayed += (int)math.floor(GameManager.level.modifiers.GetModifierValue("ChickenSpeech"));
        m_summonersSay.Emit(1);
        UpdateProgressBar();
        if (m_currentSpell && m_runesSayed >= m_currentSpell.numberOfRunes)
        {
            StopSpell();
        }
    }
    private void UpdateProgressBar()
    {
        m_progressBar.localScale = new Vector3(progress, 1f, 1f);
        if(!m_currentSpell) m_progressText.gameObject.SetActive(false);
        else
        {
            m_progressText.gameObject.SetActive(true);
            int value = (int) math.floor(progress * 100.0f);
            m_progressText.text = (value >= 10 ? "" : "0") + value + "%";
        } 
    }

    public void AddSpellInStack(SpellData _spell)
    {
        if (m_currentSpell)
        {
            if (m_spellsStack.Count > 0 && m_spellsStack[^1].spell == _spell)
            {
                var spell =m_spellsStack[^1];
                ++spell.number;
                m_spellsStack[^1] = spell;
                
                spell =m_spellsStack[^1];
            }
            else
            {
                Stack spell = new Stack(_spell);
                m_spellsStack.Add(spell);
            }
            UpdateStackUI();
        }
        else StartSpell(_spell);
    }
    public void StartSpell(SpellData _spell)
    {
        m_currentSpell = _spell;
        m_runesSayed = 0;
        m_spellIcon.sprite = m_currentSpell.icon;
        UpdateProgressBar();
    }

    public void StopSpell()
    {
        if (!m_currentSpell) return;
        
        m_currentSpell.CastingOver();
        m_currentSpell = null;
        m_spellIcon.sprite = null;
        m_runesSayed = 0;
        UpdateProgressBar();

        if (m_spellsStack.Count > 0)
        {
            StartSpell(m_spellsStack.First().spell);
            var spell =m_spellsStack[0];
            --spell.number;
            m_spellsStack[0] = spell;
            if(spell.number <= 0) m_spellsStack.RemoveAt(0);
            UpdateStackUI();
        }
    }

    public void AddSummoner()
    {
        var instance = Instantiate(m_summonerPrefab);
        Summoner summoner = instance.GetComponent<Summoner>();
        summoner.Init(m_summoners.Count);
        m_summoners.Add(summoner);
    }

    [Header("SpellStack UI")]
    [SerializeField] private GameObject m_spellStackUIPrefab;
    [SerializeField] private Transform m_spellStackUIParent;
    private List<SpellStackUI> m_stackUI;
    private void UpdateStackUI()
    {
        foreach (var spell in m_stackUI)
        {
            Destroy(spell.gameObject);
        }

        m_stackUI = new List<SpellStackUI>();
        foreach (var spell in m_spellsStack)
        {
            var instance = Instantiate(m_spellStackUIPrefab, m_spellStackUIParent);
            var spellUI = instance.GetComponent<SpellStackUI>();
            spellUI.data = spell.spell;
            spellUI.number.text = spell.number.ToString();
            spellUI.icon.sprite = spell.spell.icon;
            m_stackUI.Add(spellUI);
        }
    }

}
