using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Rigidbody2D m_rigidbody;
    
    void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        m_rigidbody.velocity = new Vector2(InputController.GetInstance().moveDirection, m_rigidbody.velocity.y);
    }
}
