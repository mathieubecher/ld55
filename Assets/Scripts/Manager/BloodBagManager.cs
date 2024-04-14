using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BloodBagManager : MonoBehaviour
{
    [SerializeField] private float m_currentQuantity;
    [SerializeField] private TextMeshProUGUI m_bagUI;
    
    [SerializeField] private Transform m_center;
    [SerializeField] private List<Sword> m_swords;
    [SerializeField] private GameObject m_swordPrefab;
    
    [SerializeField] private int m_maxQuantity = 100;
    [SerializeField] private int m_startQuantity = 40;

    [SerializeField] private bool m_isOnMouse;
    [SerializeField] private Collider2D m_collider;
    private Animator m_animator;
    public int swordNumber => m_swords.Count;

    public float bagSize => transform.localScale.x;
    public Vector2 bagCenter => m_center.position;

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
        UpdateSize();
        m_animator = GetComponent<Animator>();
    }

    private void Tick()
    {
        m_currentQuantity += GameManager.world.chaos;
        m_currentQuantity = math.min(m_currentQuantity, m_maxQuantity);
        UpdateSize();
    }

    private void UpdateSize()
    {
        float currentSize = math.remap(0f, m_maxQuantity, 5f, 10f, m_currentQuantity);
        transform.localScale = new Vector3(currentSize,currentSize,currentSize);
        m_bagUI.text = "Blood in heart : " + (int)math.floor(m_currentQuantity) + " / " + (int)math.floor(m_maxQuantity);
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
                m_animator.SetTrigger("Hit");
                UpdateSize();
            }
        }
    }

    public void SwordClick()
    {
        const float collectValue = 1;
        int realCollectValue = (int)math.floor(math.min(collectValue, m_currentQuantity));
        if (realCollectValue > 0)
        {
            GameManager.level.ClickCoockie(realCollectValue);
            m_currentQuantity -= 1;
            UpdateSize();
        }
    }

    public void AddSword()
    {
        var instance = Instantiate(m_swordPrefab);
        Sword sword = instance.GetComponent<Sword>();
        sword.Init(m_swords.Count);
        m_swords.Add(sword);
    }
}
