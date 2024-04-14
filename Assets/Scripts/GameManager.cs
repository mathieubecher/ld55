using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
#region Singleton
    private static GameManager m_instance;
    public static GameManager instance
    {
        get
        {
            if (!m_instance)
            {
                m_instance = FindObjectOfType<GameManager>();
            }
            return m_instance;
        }
    }

    [SerializeField] private LevelManager m_currentLevel;

    public static LevelManager level => instance? instance.m_currentLevel : null;
    public static WorldManager world => instance? instance.m_currentLevel.world : null;
    public static BloodBagManager bag => instance? instance.m_currentLevel.bag : null;
    public static SummoningManager summoning => instance? instance.m_currentLevel.summoning : null;

    #endregion

    public enum DescriptionType
    {
        MODIFIER, SUMMON
    }
    [Header("Description")]
    [SerializeField] private Transform m_description;
    [SerializeField] private Image m_descriptionIcon;
    [SerializeField] private TextMeshProUGUI m_descriptionTitle;
    [SerializeField] private TextMeshProUGUI m_descriptionInfo;
    [SerializeField] private TextMeshProUGUI m_descriptionCost;
    [SerializeField] private TextMeshProUGUI m_descriptionRunes;
    [SerializeField] private TextMeshProUGUI m_descriptionDescription;
    private SpellData m_currentDataDescription;
    public void DrawDescription(SpellData _data, DescriptionType _type)
    {
        m_currentDataDescription = _data;
        m_description.gameObject.SetActive(true);

        m_descriptionIcon.sprite = _data.icon;
        m_descriptionTitle.text = _data.name;
        m_descriptionInfo.text = _data.Info();
        m_descriptionCost.text = _data.cost + " Blood";
        m_descriptionRunes.text = _data.numberOfRunes + " Runes";
        m_descriptionDescription.text = _data.Description();
    }

    public void HideDescription(SpellData _data)
    {
        if (m_currentDataDescription != _data) return;
        m_description.gameObject.SetActive(false);
        m_currentDataDescription = null;
    }

    private void Update()
    {
        if (m_descriptionDescription)
        {
            m_description.position = new Vector3(m_description.position.x, GameAction.instance.mousePosition.y, m_description.position.z);
        }
    }
    

}
