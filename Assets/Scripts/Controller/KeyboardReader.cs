using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.LowLevel;

public class KeyboardReader : MonoBehaviour
{
    private string m_ButtonPressed = "";
    
    public delegate void KeyEvent(string _name);
    public static event KeyEvent OnKeyPressed;

    void Update()
    {
        foreach (var key in Keyboard.current.allKeys)
        {
            if(key.wasPressedThisFrame) OnKeyPressed?.Invoke("");
        }
    }
}
