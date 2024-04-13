using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BloodBagManager : MonoBehaviour
{
    [SerializeField, ReadOnly] private float m_currentQuantity;
    
    [SerializeField] private int m_maxQuantity = 100;
    [SerializeField] private int m_startQuantity = 40;

    [SerializeField] private bool m_isOnMouse;
    [SerializeField] private Collider2D m_collider;

    private void OnEnable()
    {
        GameAction.OnMouseClick += OnMouseClick;
        GameManager.level.OnTick += Tick;
    }

    private void OnDisable()
    {
        GameAction.OnMouseClick -= OnMouseClick;
        GameManager.level.OnTick -= Tick;
    }

    private void Awake()
    {
        m_currentQuantity = m_startQuantity;
    }

    private void Tick()
    {
        m_currentQuantity += GameManager.world.chaos;
    }
    void Update()
    {
        Vector2 pos = GameAction.instance.mousePosition;
        m_isOnMouse = m_collider.OverlapPoint(pos);
    }

    private void OnMouseClick()
    {
        if(m_isOnMouse)
        {
            const float collectValue = 1;
            int realCollectValue = (int)math.floor(math.min(collectValue, m_currentQuantity));
            if (realCollectValue > 0)
            {
                GameManager.level.ClickCoockie(realCollectValue);
                m_currentQuantity -= 1;
            }
        }
    }
}
