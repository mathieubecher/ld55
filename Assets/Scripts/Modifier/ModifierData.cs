using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ModifierData
{
    public string name;
    public float value;

    public ModifierData(ModifierData _other)
    {
        name = _other.name;
        value = _other.value;
    }
}
 