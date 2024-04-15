using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modifiers : MonoBehaviour
{
    public List<ModifierData> modifiers = new List<ModifierData>();
    public float GetModifierValue(string _name)
    {
        var modifier = modifiers.Find(x => x.name == _name);
        return modifier?.value ?? 1.0f;
    }
    private void Start()
    {
        Init();
    }

    private void Init()
    {
        modifiers = new List<ModifierData>();
    }

    public void AddModifier(ModifierData modifierData)
    {
        var currModifier = modifiers.Find(x => x.name == modifierData.name);
        if (currModifier != null)
        {
            currModifier.value *= modifierData.value;
        }
        else modifiers.Add(new ModifierData(modifierData));
    }
}
