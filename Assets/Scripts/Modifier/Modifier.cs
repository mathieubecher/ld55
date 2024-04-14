using UnityEngine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Modifier : MonoBehaviour
{
    [SerializeField] private Image m_icon;
    [SerializeField] private ModifierSpell m_data;
    
    public void Init(ModifierSpell _data)
    {
        m_data = _data;
        m_icon.sprite = m_data.icon;
    }

    public void Select()
    {
        if(GameManager.level.TrySpell(m_data, 1.0f))
        {
            GameManager.summoning.AddSpellInStack(m_data);
            Destroy(gameObject);
        }
    }
}
