using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Spell/New modifier", order = 1)]
public class ModifierSpell : SpellData
{
    public ModifierData data;
    public string description;
    
    public override void CastingOver()
    {
        GameManager.level.modifiers.AddModifier(data);
    }
    public override string Info()
    {
        return "Upgrade";
    }

    public override string Description()
    {
        return description;
    }
}
