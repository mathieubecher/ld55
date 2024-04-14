using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class SummoningManager : MonoBehaviour
{
    [SerializeField] private Image m_spellIcon;
    [SerializeField] private TextMeshProUGUI m_sayUI;
    [SerializeField] private Transform m_progressBar;
    [SerializeField] private List<Summoner> m_summoners;
    [SerializeField] private GameObject m_summonerPrefab;

    private SpellData m_currentSpell;
    private int m_runesSayed = 0;
    public float circleSize => 10;
    public Vector2 circleCenter => transform.position + Vector3.up * 0.5f;

    public float progress => m_currentSpell && m_currentSpell.numberOfRunes > 0 ? m_runesSayed / (float)m_currentSpell.numberOfRunes : 0.0f;
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
        
        int length = m_sayUI.text.Length;
        m_sayUI.text = m_sayUI.text.Remove(0, length - math.min(length, 4)) + _keyName;
        
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
    }
    
    public void AddSummoner()
    {
        var instance = Instantiate(m_summonerPrefab);
        Summoner summoner = instance.GetComponent<Summoner>();
        summoner.Init(m_summoners.Count);
        m_summoners.Add(summoner);
    }
}
