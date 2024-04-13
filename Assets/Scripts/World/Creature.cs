using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    [SerializeField] private SpriteRenderer m_sprite;
    
    private CreatureData m_data;
    private float m_currentLife = 0f;
    
    public float chaos => m_data ? m_data.chaos : 0.0f;
    
    public void Init(CreatureData _data)
    {
        m_data = _data;
        m_currentLife = m_data.life;
        m_sprite.sprite = m_data.avatar;
    }
}
