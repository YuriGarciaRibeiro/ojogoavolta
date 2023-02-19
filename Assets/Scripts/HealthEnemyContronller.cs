using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemyContronller : MonoBehaviour
{
    public int healthAct;
    public int healthMax = 100;
    public int damage;

    private Animator anim;
    public CombatEnemy scriptCombat;

    public void TakeDamage(int damage)
    {
        healthAct -= damage;
        

        if (healthAct <= 0)
        {
            healthAct = 0;
            scriptCombat.vivo = false;
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
        
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }


    void Start()
    {
        healthAct = healthMax;
        anim = GetComponent<Animator>();
        scriptCombat = GetComponent<CombatEnemy>();
    }

    void Update()
    {
        
    }
}
