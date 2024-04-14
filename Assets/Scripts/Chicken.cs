using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    private Collider2D m_collider;
    [SerializeField] private float m_duration = 5.0f;
    private float m_start;

    private void Awake()
    {
        m_start = Time.time;
        m_collider = GetComponent<Collider2D>();
    }
    private void OnEnable()
    {
        GameAction.OnMouseClick += OnMouseClick;
    }

    private void OnDisable()
    {
        GameAction.OnMouseClick -= OnMouseClick;
    }

    private void FixedUpdate()
    {
        if(Time.time > m_start + m_duration)
            Destroy(gameObject);
    }

    private void OnMouseClick()
    {
        Vector2 pos = GameAction.instance.mousePosition;
        if(m_collider.OverlapPoint(pos))
        {
            GameManager.summoning.AddSummoner();
            Destroy(gameObject);
        }
    }

}
