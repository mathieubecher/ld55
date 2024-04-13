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
    [SerializeField] private TextMeshProUGUI m_sayUI;
    
    void Start()
    {
        
        InputSystem.onEvent += InputSystem_onEvent;
    }

    private void InputSystem_onEvent(InputEventPtr eventPtr, InputDevice device)
    {
        if (!device.description.deviceClass.Equals("Keyboard") || !eventPtr.IsA<StateEvent>() && !eventPtr.IsA<DeltaStateEvent>())
            return;
        var controls = device.allControls;
        var buttonPressPoint = InputSystem.settings.defaultButtonPressPoint;
        for (var i = 0; i < controls.Count; ++i)
        {
            var control = controls[i] as ButtonControl;
            if (control == null || control.synthetic || control.noisy)
                continue;
            if (control.ReadValueFromEvent(eventPtr, out var value) && value >= buttonPressPoint)
            {
                m_ButtonPressed = control.name;
                break;
            }
        }
    }
    
    private void Update()
    {
        if(m_ButtonPressed.Length > 0)
        {
            int length = m_sayUI.text.Length;
            m_sayUI.text = m_sayUI.text.Remove(0, length - math.min(length, 4)) + m_ButtonPressed;
            m_ButtonPressed = "";
        }
    }

}
