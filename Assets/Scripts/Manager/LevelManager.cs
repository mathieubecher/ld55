using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private WorldManager m_currentWorld;
    [SerializeField] private BloodBagManager m_currentBag;
    [SerializeField] private SummoningManager m_summoning;
    
    public WorldManager world => m_currentWorld;
    public BloodBagManager bag => m_currentBag;
    public SummoningManager summoning => m_summoning;
    
    [SerializeField] private TextMeshProUGUI m_scoreUI;

    private float m_frameTick = 0f;
    private int m_bloodScore = 0;
    public int bloodScore
    {
        get => m_bloodScore;
        set => m_bloodScore = value;
    }
    
    public delegate void SimpleEvent();
    public event SimpleEvent OnTick;

    private void Awake()
    {
        m_bloodScore = 0;
    }

    private void FixedUpdate()
    {
        m_frameTick += Time.fixedDeltaTime;
        
        float tickTime = 1f;
        if (m_frameTick >= tickTime)
        {
            OnTick?.Invoke();
            m_frameTick = 0f;
        }
    }

    public void ClickCoockie(int _value)
    {
        bloodScore += _value;
        m_scoreUI.text = "Score : " + bloodScore;
    }
}
