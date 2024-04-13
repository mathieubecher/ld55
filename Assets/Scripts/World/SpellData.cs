using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Spell/New spell", order = 1)]
public class SpellData : ScriptableObject
{
    public string name;
    public Sprite icon;
    public int numberOfRunes;

    public virtual void CastingOver()
    {
        
    }
}
