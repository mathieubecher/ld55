using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
#region Singleton
    private static GameManager m_instance;
    public static GameManager instance
    {
        get
        {
            if (!m_instance)
            {
                m_instance = FindObjectOfType<GameManager>();
            }
            return m_instance;
        }
    }

    [SerializeField] private LevelManager m_currentLevel;

    public static LevelManager level => instance.m_currentLevel;
    public static WorldManager world => instance.m_currentLevel.world;
    public static BloodBagManager bag => instance.m_currentLevel.bag;
    public static SummoningManager summoning => instance.m_currentLevel.summoning;

    #endregion

}
