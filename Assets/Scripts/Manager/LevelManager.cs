using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private WorldManager m_currentWorld;
    [SerializeField] private BloodBagManager m_currentBag;
    [SerializeField] private SummoningManager m_summoning;
    [SerializeField] private Modifiers m_mofidifiers;
    [SerializeField] private int m_tickPerSecond = 10;
    private int m_currentTick;
    
    public int currentTick => m_currentTick;
    
    public WorldManager world => m_currentWorld;
    public BloodBagManager bag => m_currentBag;
    public SummoningManager summoning => m_summoning;
    public Modifiers modifiers => m_mofidifiers;
    
    [SerializeField] private TextMeshProUGUI m_scoreUI;
    
    public int bloodScore
    {
        get => m_bloodScore;
        set
        {
            m_bloodScore = value;
            m_scoreUI.text = "Score : " + bloodScore;
        }
    }

    private float m_frameTick = 0f;

    private int m_bloodScore = 0;

    public delegate void SimpleEvent();
    public event SimpleEvent OnTick;

    private void Awake()
    {
        m_bloodScore = 0;
    }

    private void FixedUpdate()
    {
        m_frameTick += Time.fixedDeltaTime;
        
        if (m_frameTick >= 1/(float)m_tickPerSecond)
        {
            ++m_currentTick;
            OnTick?.Invoke();
            m_frameTick = 0f;
        }
    }

    public void ClickCoockie(int _value)
    {
        bloodScore += _value;
        m_scoreUI.text = "Score : " + bloodScore;
    }
    
    public bool TrySpell(SpellData _spell, float _multiplier)
    {
        int cost = (int)math.ceil(_spell.cost * _multiplier);
        if (bloodScore >= cost)
        {
            bloodScore -= cost;
            m_scoreUI.text = "Score : " + bloodScore;
            return true;
        }

        return false;
    }

}
