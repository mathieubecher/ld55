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
        return "owned : " + GameManager.world.NumberOfCreature(creature);
    }
    public override string Description()
    {
        int number = GameManager.world.NumberOfCreature(creature);
        return "Each " + creature.name + " generating " + creature.chaos + " chaos per second. \n" +
               number + " " + creature.name + "collecting " + creature.chaos * number + " chaos per second.";
    }
}
