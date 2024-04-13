using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Spell : MonoBehaviour
{
    [SerializeField] private Image m_icon;
    [SerializeField] private TextMeshProUGUI m_name;
    [SerializeField] private TextMeshProUGUI m_cost;

    private SpellData m_data;

    public void Init(SpellData _data)
    {
        m_data = _data;
        m_icon.sprite = m_data.icon;
        m_name.text = m_data.name;
        m_cost.text = m_data.cost + " blood, " + m_data.numberOfRunes + " runes";
    }

    public void Select()
    {
        if(GameManager.level.TrySpell(m_data)) GameManager.summoning.StartSpell(m_data);
    }
}
