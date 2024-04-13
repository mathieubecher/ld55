using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Coockie : MonoBehaviour
{
    [SerializeField] private bool m_isOnMouse;
    [SerializeField] private Collider2D m_collider;

    private void OnEnable()
    {
        GameAction.OnMouseClick += OnMouseClick;
    }

    private void OnDisable()
    {
        GameAction.OnMouseClick -= OnMouseClick;
    }

    void Update()
    {
        Vector2 pos = GameAction.instance.mousePosition;
        m_isOnMouse = m_collider.OverlapPoint(pos);
    }

    private void OnMouseClick()
    {
        GameManager.instance.ClickCoockie(1);
    }
}
