using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    private List<Creature> m_creaturesInWorld;
    [SerializeField] private TextMeshProUGUI m_chaosUI;
    [SerializeField] private GameObject m_creaturePrefab;
    public float chaos
    {
        get
        {
            float chaos = m_defaultLevelOfChaos;
            foreach (var creature in m_creaturesInWorld)
            {
                chaos += creature.chaos;
            }
            return chaos;
        }
    }
    
    [SerializeField] private float m_defaultLevelOfChaos = 1.0f;
    
    void Awake()
    {
        m_creaturesInWorld = new List<Creature>();
    }

    void FixedUpdate()
    {
        m_chaosUI.text = "Chaos : " + chaos.ToString("F2");
    }

    public void AddCreature(CreatureData _creature)
    {
        var instance = Instantiate(m_creaturePrefab, transform.parent);
        var creature = instance.GetComponent<Creature>();
        creature.Init(_creature);
        
        m_creaturesInWorld.Add(creature);
    }
}
