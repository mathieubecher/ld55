using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class SummoningManager : MonoBehaviour
{
    [SerializeField] private Image m_spellIcon;
    [SerializeField] private TextMeshProUGUI m_sayUI;
    [SerializeField] private Transform m_progressBar;

    private SpellData m_currentSpell;
    private int m_runesSayed = 0;

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
        int length = m_sayUI.text.Length;
        m_sayUI.text = m_sayUI.text.Remove(0, length - math.min(length, 4)) + _keyName;
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

}
