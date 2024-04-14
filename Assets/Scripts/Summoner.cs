using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Summoner : MonoBehaviour
{
    private int m_number;
    private int m_maxInARow = 8;
    private float m_rowSpace = 0.8f;
    private float m_rowOffset = 0.2f;
    private void OnEnable()
    {
        GameManager.level.OnTick += Tick;
    }

    private void OnDisable()
    {
        if(GameManager.level) GameManager.level.OnTick -= Tick;
    }
    
    public void Init(int _number)
    {
        var summoning = GameManager.summoning;
        m_number = _number;
        bool isLeft = m_number % 2 == 0;
        int rowNumber = (int) math.floor(m_number / (float)m_maxInARow);
        transform.localScale = new Vector3(isLeft ? -1f : 1f, 1f, 1f);
        Vector2 offset = Vector2.right * (isLeft ? -1f : 1f) * (math.floor(m_number % m_maxInARow / 2.0f) + 0.5f) * summoning.circleSize / m_maxInARow;
        offset += Vector2.up * rowNumber * m_rowSpace;
        offset += Vector2.right * (rowNumber % 2 == 0 ? 1f : -1f) * m_rowOffset;
        transform.position = summoning.circleCenter + offset;
    }
    
    private void Tick()
    {
        if((GameManager.level.currentTick - m_number) % 10 == 0)
            GameManager.summoning.SummonerKeyPressed();
    }


}
