using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierListUI : MonoBehaviour
{
    [SerializeField] private List<ModifierSpell> m_modifiers;
    [SerializeField] private GameObject m_modifierUIPrefab;
    
    void Awake()
    {
        for (int i = transform.childCount - 1; i >= 0; --i)
        {
            Destroy(transform.GetChild(i));
        }

        foreach (var modifierSpell in m_modifiers)
        {
            var instance = Instantiate(m_modifierUIPrefab, transform);
            instance.GetComponent<Modifier>().Init(modifierSpell);
        }
    }
}
