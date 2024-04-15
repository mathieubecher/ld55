using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ModifierListUI : MonoBehaviour
{
    [SerializeField] private List<ModifierSpell> m_modifiers;
    [SerializeField] private GameObject m_modifierUIPrefab;

    private int m_modifierNumber = 0;
    void Awake()
    {
        for (int i = transform.childCount - 1; i >= 0; --i)
        {
            Destroy(transform.GetChild(i));
        }

        m_modifiers.Sort((x, y) => x.cost.CompareTo(y.cost));
        for (int i = 0; i < m_modifiers.Count && i < 8; ++i)
        {
            var modifierSpell = m_modifiers[i];
            var instance = Instantiate(m_modifierUIPrefab, transform);
            instance.GetComponent<Modifier>().Init(modifierSpell, this);
            ++m_modifierNumber;
        }
    }

    public void DrawNewModifier()
    {
        if (m_modifierNumber < m_modifiers.Count)
        {
            var modifierSpell = m_modifiers[m_modifierNumber];
            var instance = Instantiate(m_modifierUIPrefab, transform);
            instance.GetComponent<Modifier>().Init(modifierSpell, this);
            ++m_modifierNumber;
        }
    }

    #if UNITY_EDITOR
    [ContextMenu("GetAllModifier")]
    public void GetAllModifier()
    {
        m_modifiers = new List<ModifierSpell>();
        var guids = AssetDatabase.FindAssets("t:"+ nameof(ModifierSpell));
        for(int i = 0; i < guids.Length; i++)
        {
            string path = AssetDatabase.GUIDToAssetPath(guids[i]);
            m_modifiers.Add(AssetDatabase.LoadAssetAtPath<ModifierSpell>(path));
        }
        m_modifiers.Sort((x, y) => x.cost.CompareTo(y.cost));
    }
    #endif
}
