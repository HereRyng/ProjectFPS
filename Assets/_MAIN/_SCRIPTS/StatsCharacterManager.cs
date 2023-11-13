using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsCharacterManager : MonoBehaviour
{
    public CharacterBasicStats Stats => stats;
    [SerializeField] private CharacterBasicStats stats;

}
