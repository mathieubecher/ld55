using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private int m_number;
    private void OnEnable()
    {
        GameManager.level.OnTick += Tick;
    }

    private void OnDisable()
    {
        GameManager.level.OnTick -= Tick;
    }
    
    public void Init(int _number)
    {
        m_number = _number;
    }
    
    private void Tick()
    {
        if((GameManager.level.currentTick - m_number) % 10 == 0)
            GameManager.bag.SwordClick();
    }

    private void FixedUpdate()
    {
        var bag = GameManager.bag;
        float angle = Time.time * 2f + m_number * 20f;
        
        Vector2 offset = Quaternion.Euler(0f,0f,angle) * Vector2.left * (bag.bagSize / 2f + 0.8f);
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
        transform.position = bag.bagCenter + offset;
    }

}
