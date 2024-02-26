using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Moves" , menuName = "ScriptableObjects/Moves")]
public class Moves : ScriptableObject
{
    [Header("Adjustable Attributes")]
    [SerializeField]public string name;
    [SerializeField]public DamageType type;
    [SerializeField]public string description;
    [SerializeField]public int damage;


}
