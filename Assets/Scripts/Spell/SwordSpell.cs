using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "Spell/Sword", order = 1)]
public class SwordSpell : SpellData
{
    public override void CastingOver()
    {
        GameManager.bag.AddSword();
    }
    
    public override string Info()
    {
        return "owned : " + GameManager.bag.swordNumber;
    }
    
    public override string Description()
    {
        int number = GameManager.bag.swordNumber;
        float bps = GameManager.level.tickPerSecond / (float)GameManager.level.swordCooldown * GameManager.level.modifiers.GetModifierValue("SwordCollect");
        return "A sword that regularly attacks the heart to collect blood. \n" +
               "Each sword collecting " + bps + " blood per second. \n" +
               number + " swords collecting " + bps * number + " blood per second.";
    }
}
