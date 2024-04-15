using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
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
            foreach (var creature in m_creatures)
            {
                chaos += creature.Key.chaos * GameManager.level.modifiers.GetModifierValue(creature.Key.name+"Chaos") * creature.Value;
            }
            return chaos;
        }
    }
    
    [SerializeField] private float m_defaultLevelOfChaos = 1.0f;
    
    void Awake()
    {
        m_creatures = new Dictionary<CreatureData, int>(); 
    }

    void FixedUpdate()
    {
        m_chaosUI.text = "Chaos per second : " + (chaos * GameManager.level.tickPerSecond).ToString("F2");
    }

    public void AddCreature(CreatureData _creature)
    {
        if (!m_creatures.ContainsKey(_creature)) m_creatures[_creature] = 0;
        ++m_creatures[_creature];
    }
}
