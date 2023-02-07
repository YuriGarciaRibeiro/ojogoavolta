using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemyContronller : MonoBehaviour
{
    public int healthAct;
    public int healthMax = 100;
    public int damage;

    void TakeDamage(int damage)
    {
        healthAct -= damage;

        if (healthAct <= 0)
        {
            healthAct = 0;
            Dead();
        }
    }

    private void Dead()
    {
        Destroy(gameObject);
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }


    void Start()
    {
        healthAct = healthMax;
    }

    void Update()
    {
        
    }
}
