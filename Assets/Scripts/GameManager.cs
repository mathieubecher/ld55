using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int m_score = 0;
    [SerializeField] private TextMeshProUGUI m_scoreUI;
    public int score
    {
        get => m_score;
        set => m_score = value;
    }

    private void Awake()
    {
        m_score = 0;
    }
    
    public void ClickCoockie()
    {
        ++score;
        m_scoreUI.text = "Score : " + score;
    }
}
