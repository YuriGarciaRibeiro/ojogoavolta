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
        

        if (healthAct <= 0)
        {
            healthAct = 0;
            Dead();
        }
        else
        {
            anim.SetTrigger("Take Damage");
        }

        
    }

    public  void Dead()
    {
        anim.SetTrigger("Die 02");
        //faz parar de seguir
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
