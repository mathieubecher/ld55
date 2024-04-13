using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameAction : MonoBehaviour
{
    #region Singleton
    private static GameAction m_instance;
    public static GameAction instance
    {
        get
        {
            if (!m_instance)
            {
                m_instance = FindObjectOfType<GameAction>();
            }
            return m_instance;
        }
    }
    #endregion

    public delegate void SimpleEvent();
    public static event SimpleEvent OnMouseClick;
    public static event SimpleEvent OnMouseRelease;
    public Vector2 mousePosition
    {
        get
        {
            if (Mouse.current is Mouse mouse)
            {
                return Camera.main.ScreenToWorldPoint(mouse.position.value);
            }

            return Vector2.zero;
        }
    } 
    public void ReadClickInput(InputAction.CallbackContext _context)
    {
        if (_context.performed)
            OnMouseClick?.Invoke();
        else if (_context.canceled)
        {
            OnMouseRelease?.Invoke();
        }
    }

}
