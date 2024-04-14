using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Spell/New modifier", order = 1)]
public class ModifierSpell : SpellData
{
    public ModifierData data;
    
    public override void CastingOver()
    {
        GameManager.level.modifiers.AddModifier(data);
    }
}
