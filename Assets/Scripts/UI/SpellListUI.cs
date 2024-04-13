using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellListUI : MonoBehaviour
{
    [SerializeField] private List<SpellData> m_spells;
    [SerializeField] private GameObject m_spellUIPrefab;
    
    // Start is called before the first frame update
    void Awake()
    {
        for (int i = transform.childCount - 1; i >= 0; --i)
        {
            Destroy(transform.GetChild(i));
        }

        foreach (var spellData in m_spells)
        {
            var instance = Instantiate(m_spellUIPrefab, transform);
            instance.GetComponent<Spell>().Init(spellData);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
