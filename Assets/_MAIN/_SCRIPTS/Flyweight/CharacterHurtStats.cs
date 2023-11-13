using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterHurtStats", menuName = "Stats/StatsCharacterManager/CharacterHurtStats", order = 0)]
public class CharacterHurtStats : CharacterBasicStats
{
    public int DamagePush => damagePush;
    [SerializeField] private int damagePush;

}
