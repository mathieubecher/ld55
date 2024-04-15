using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private ParticleSystem m_hit;
    private Animator m_animator;
    private int m_number;
    private float m_distanceOffset = 0.8f;
    private int m_swordInARow = 18;
    private float m_swordOffset = 0.5f;
    private void OnEnable()
    {
        GameManager.level.OnTick += Tick;
    }

    private void OnDisable()
    {
        if(GameManager.level) GameManager.level.OnTick -= Tick;
    }

    private void Awake()
    {
        m_animator = GetComponent<Animator>();
    }
    
    public void Init(int _number)
    {
        m_number = _number;
        FixedUpdate();
    }
    
    private void Tick()
    {
        if((GameManager.level.currentTick - m_number) % GameManager.level.swordCooldown == 0)
        {
            m_hit.Emit(1);
            m_animator.SetTrigger("Hit");
            GameManager.bag.SwordClick();
        }
    }

    private void FixedUpdate()
    {
        var bag = GameManager.bag;
        int row = (int)math.floor(m_number / (float)m_swordInARow);
        
        float angle = Time.time * 2f + (m_number + (row % 2 == 0? 0.0f : 0.5f)) * 360f / m_swordInARow;

        Vector2 offset = Quaternion.Euler(0f,0f,angle) * Vector2.left * (bag.bagSize / 2f + m_distanceOffset + row * m_swordOffset);
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
        transform.position = bag.bagCenter + offset;
    }

}
