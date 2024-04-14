using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Spell/New summon", order = 1)]
public class SummonSpellData : SpellData
{
    public CreatureData creature;
    
    public override void CastingOver()
    {
        GameManager.world.AddCreature(creature);
    }
    
    public override string Info()
    {
        return "owned : " + 0;
    }
    public override string Description()
    {
        return "";
    }
}
