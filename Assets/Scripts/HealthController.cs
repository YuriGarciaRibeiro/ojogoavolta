using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{

    public int healthAct;
    public int healthMax = 100;


    void TakeDamage(int damage) {
        healthAct -= damage;

        if (healthAct <= 0) { 
            healthAct= 0;
            Dead();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Enemy")){
            TakeDamage(collision.gameObject.GetComponent<HealthEnemyContronller>().damage);

        }
    }
    private void Dead()
    {
        
    }

    void Start()
    {
        healthAct = healthMax;
    }

    
    void Update()
    {
        
    }
}
