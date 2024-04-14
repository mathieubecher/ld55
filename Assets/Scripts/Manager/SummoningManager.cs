using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SummoningManager : MonoBehaviour
{
    [SerializeField] private Image m_spellIcon;
    [SerializeField] private ParticleSystem m_say;
    [SerializeField] private ParticleSystem m_summonersSay;
    [SerializeField] private Transform m_progressBar;
    [SerializeField] private List<Summoner> m_summoners;
    [SerializeField] private GameObject m_summonerPrefab;

    private List<SpellData> m_spellsStack;

    private SpellData m_currentSpell;
    private int m_runesSayed = 0;
    public float circleSize => 10;
    public Vector2 circleCenter => transform.position + Vector3.up * 0.5f;

    public float progress => m_currentSpell && m_currentSpell.numberOfRunes > 0 ? m_runesSayed / (float)m_currentSpell.numberOfRunes : 0.0f;

    void Awake()
    {
        m_spellsStack = new List<SpellData>();
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
        
        ++m_runesSayed;
        UpdateProgressBar();
        if (m_currentSpell && m_runesSayed >= m_currentSpell.numberOfRunes)
        {
            StopSpell();
        }
    }

    public void SummonerKeyPressed()
    {
        if (!m_currentSpell) return;
        ++m_runesSayed;
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
    }

    public void AddSpellInStack(SpellData _spell)
    {
        if(m_currentSpell) m_spellsStack.Add(_spell);
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
            StartSpell(m_spellsStack.First());
            m_spellsStack.RemoveAt(0);
        }
    }
    
    public void AddSummoner()
    {
        var instance = Instantiate(m_summonerPrefab);
        Summoner summoner = instance.GetComponent<Summoner>();
        summoner.Init(m_summoners.Count);
        m_summoners.Add(summoner);
    }
}
