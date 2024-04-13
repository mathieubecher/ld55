using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Creature/New Creature", order = 1)]
public class CreatureData : ScriptableObject
{
    public string name;
    public Sprite avatar;
    public float life;
    public float chaos;
}
