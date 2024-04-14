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
        return "A sword that regularly attacks the heart to collect blood. \n" +
               "Each sword collecting " + 0.2f + " blood per second. \n" +
               GameManager.bag.swordNumber + "swords collecting " + 0.2f * GameManager.bag.swordNumber + " blood per second.";
    }
}
