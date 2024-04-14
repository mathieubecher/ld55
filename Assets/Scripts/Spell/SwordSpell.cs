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
}
