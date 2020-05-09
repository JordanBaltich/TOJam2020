using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/MinionData", order = 1)]
public class MinionData : ScriptableObject
{
    public float maxHealth, currentHealth;
    public float attackPower;
    public float moveSpeed;
    public bool isSelected;
}
