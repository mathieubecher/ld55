using System;
using UnityEngine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Modifier : MonoBehaviour
{
    [SerializeField] private Image m_icon;
    [SerializeField] private ModifierSpell m_data;
    private ModifierListUI m_list;
    public void Init(ModifierSpell _data, ModifierListUI _list)
    {
        m_data = _data;
        m_icon.sprite = m_data.icon;
        m_list = _list;
    }

    public void FixedUpdate()
    {
        m_icon.color = (GameManager.level.CanSpell(m_data, 1.0f))? Color.white : Color.Lerp(Color.white, Color.black, 0.5f);
    }

    public void Select()
    {
        if(GameManager.level.TrySpell(m_data, 1.0f))
        {
            GameManager.summoning.AddSpellInStack(m_data);
            m_list.DrawNewModifier();
            Destroy(gameObject);
        }
    }
    
    public void OnPointerEnter()
    {
        GameManager.instance.DrawDescription(m_data, m_data.cost, GameManager.DescriptionType.MODIFIER);
    }

    public void OnPointerExit()
    {
        GameManager.instance.HideDescription(m_data);
    }
}
