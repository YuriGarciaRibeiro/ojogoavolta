using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemyContronller : MonoBehaviour
{
    public int healthAct;
    public int healthMax = 100;
    public int damage;

    private Animator anim;

    public void TakeDamage(int damage)
    {
        healthAct -= damage;
        anim.SetTrigger("Take Damage");

        if (healthAct <= 0)
        {
            healthAct = 0;
            Dead();
        }
    }

    public  void Dead()
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
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
    }
}
