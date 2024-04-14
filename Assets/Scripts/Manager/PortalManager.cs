using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class PortalManager : MonoBehaviour
{
    [SerializeField] private GameObject m_chickenPrefab;
    [SerializeField] private int m_cooldown = 10;

    private int m_lastChicken = 0;
    
    private void OnEnable()
    {
        GameManager.level.OnTick += Tick;
    }

    private void OnDisable()
    {
        GameManager.level.OnTick -= Tick;
    }

    private void Tick()
    {
        ++m_lastChicken;
        if (m_lastChicken >= m_cooldown)
        {
            m_lastChicken = 0;
            var instance = Instantiate(m_chickenPrefab, transform.position, Quaternion.identity);
            instance.GetComponent<Rigidbody2D>().velocity = Quaternion.Euler(0f, 0f, Random.Range(-45f, 0f)) * Vector2.left * Random.Range(6f, 15f);
        }
    }
}
