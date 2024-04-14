using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    private List<Creature> m_creaturesInWorld;
    [SerializeField] private TextMeshProUGUI m_chaosUI;
    [SerializeField] private GameObject m_creaturePrefab;
    private Dictionary<CreatureData, int> m_creatures;

    public int NumberOfCreature(CreatureData _creature)
    {
        return m_creatures.ContainsKey(_creature) ? m_creatures[_creature] : 0;
    }
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
        m_creatures = new Dictionary<CreatureData, int>(); 
    }

    void FixedUpdate()
    {
        m_chaosUI.text = "Chaos per second : " + (chaos * GameManager.level.tickPerSecond).ToString("F2");
    }

    public void AddCreature(CreatureData _creature)
    {
        var instance = Instantiate(m_creaturePrefab, transform.parent);
        var creature = instance.GetComponent<Creature>();
        creature.Init(_creature);

        if (!m_creatures.ContainsKey(_creature)) m_creatures[_creature] = 0;
        ++m_creatures[_creature];
        
        m_creaturesInWorld.Add(creature);
    }
}
