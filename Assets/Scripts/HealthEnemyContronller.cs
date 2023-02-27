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
    public Material material;
    public Color corOriginal;
    public void TakeDamage(int damage)
    {
        healthAct -= damage;


        if (healthAct <= 0)
        {
            healthAct = 0;

            material.color = Color.red;
            Invoke("RestaurarCorOriginal", 0.3f);
            StartCoroutine("tempoMorte");
            scriptCombat.vivo = false;
        }
        else
        {
            
            
            anim.SetTrigger("Take Damage");
            material.color = Color.red;
            Invoke("RestaurarCorOriginal", 0.3f);

        }
    }

    void RestaurarCorOriginal()
    {
        material.color = Color.white; // Restaura a cor original do material
    }

    public  void Dead()
    {
        Destroy(gameObject);
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    IEnumerator tempoMorte() {

        if (scriptCombat.vivo == true)
        {
            anim.SetTrigger("Die 02");
            yield return new WaitForSeconds(3.1f);
            Dead();
        }     
    
    }



    void Start()
    {
        healthAct = healthMax;
        anim = GetComponent<Animator>();
        scriptCombat = GetComponent<CombatEnemy>();
        Material material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        
    }
}
