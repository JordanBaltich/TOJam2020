using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    MinionData unitData;

    public void FindUnitType()
    {
        if (GetComponent<MinionController>() != null)
        {
            unitData = GetComponent<MinionController>().m_Data;
            print("I am a Player Unit!");
        }
        if (GetComponent<AIMinionController>() != null)
        {
            unitData = GetComponent<AIMinionController>().m_Data;
            print("I am an AI Unit!");
        }
    }

    public void Heal(float healAmount)
    {
        unitData.currentHealth += healAmount;

        if (unitData.currentHealth + healAmount >= unitData.maxHealth)
        {
            unitData.currentHealth = unitData.maxHealth;
        }
    }

    public void TakeDamage(float damage)
    {
        print("I made it here");
        if (unitData != null)
        {
            unitData.currentHealth -= damage;
            print(gameObject.name + "Recieved " + damage + " Damage!");

            if (unitData.currentHealth - damage <= 0)
            {
                unitData.currentHealth = 0;
            }
        }
        else
        {
            print("unit data could not be found");
        }
       
    }

    public void GetTotalHealthPool(List<MinionData> blobsDatas)
    {
        for (int i = 0; i < blobsDatas.Count; i++)
        {
            unitData.maxHealth += blobsDatas[i].maxHealth;
            unitData.currentHealth += blobsDatas[i].currentHealth;
        }
    }

    public void DistributeHealth(List<MinionData> blobsDatas)
    {
        float blobsNewCurrentHealth = unitData.currentHealth / blobsDatas.Count;

        for (int i = 0; i < blobsDatas.Count; i++)
        {
            blobsDatas[i].currentHealth = blobsNewCurrentHealth;
        }
    }
}
