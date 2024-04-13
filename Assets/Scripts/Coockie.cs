using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Coockie : MonoBehaviour
{
    [SerializeField] private bool m_isOnMouse;
    [SerializeField] private Collider2D m_collider;
    
    
    void Update()
    {   
        if (Mouse.current is Mouse mouse)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(mouse.position.value);
            Debug.DrawLine(pos, pos + Vector2.up, Color.red);
            m_isOnMouse = m_collider.OverlapPoint(pos);
        }
    }
}
