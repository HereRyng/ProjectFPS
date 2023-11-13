using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterBasicStats", menuName = "Stats/StatsCharacterManager/CharacterBasicStats", order = 0)]
public class CharacterBasicStats : ScriptableObject
{
    public float Speed => speed;
    [SerializeField] private float speed;
    public virtual int MaxHealth => maxHealth;
    [SerializeField] private int maxHealth;

}
