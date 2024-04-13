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
#endregion
    
    [SerializeField] private TextMeshProUGUI m_scoreUI;
    private int m_blood = 0;
    public int score
    {
        get => m_blood;
        set => m_blood = value;
    }

    private void Awake()
    {
        m_blood = 0;
    }
    
    public void ClickCoockie(int _value)
    {
        score += _value;
        m_scoreUI.text = "Score : " + score;
    }
}
