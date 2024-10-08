using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Spell : MonoBehaviour
{
    [SerializeField] private Image m_icon;
    [SerializeField] private TextMeshProUGUI m_name;
    [SerializeField] private TextMeshProUGUI m_cost;
    [SerializeField] private TextMeshProUGUI m_runes;

    private int m_number = 0;

    private SpellData m_data;

    public void Init(SpellData _data)
    {
        m_data = _data;
        m_icon.sprite = m_data.icon;
        m_name.text = m_data.name;
        m_cost.text = m_data.cost.ToString();
        m_runes.text = m_data.numberOfRunes.ToString();
    }

    public void FixedUpdate()
    {
        m_icon.color = (GameManager.level.CanSpell(m_data, 1.0f))? Color.white : Color.Lerp(Color.white, Color.black, 0.5f);
    }
    
    public void Select()
    {
        if(GameManager.level.TrySpell(m_data, math.pow(1.2f, m_number)))
        {
            GameManager.summoning.AddSpellInStack(m_data);
            ++m_number;
            int cost = (int)math.ceil(m_data.cost * math.pow(1.2f, m_number));
            m_cost.text = cost.ToString();
            m_runes.text = m_data.numberOfRunes.ToString();
        }
    }

    public void OnPointerEnter()
    {
        GameManager.instance.DrawDescription(m_data, (int)math.ceil(m_data.cost * math.pow(1.2f, m_number)), GameManager.DescriptionType.SUMMON);
    }

    public void OnPointerExit()
    {
        GameManager.instance.HideDescription(m_data);
    }
}
