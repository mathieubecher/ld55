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

    public static LevelManager level => instance? instance.m_currentLevel : null;
    public static WorldManager world => instance? instance.m_currentLevel.world : null;
    public static BloodBagManager bag => instance? instance.m_currentLevel.bag : null;
    public static SummoningManager summoning => instance? instance.m_currentLevel.summoning : null;

    #endregion

}
