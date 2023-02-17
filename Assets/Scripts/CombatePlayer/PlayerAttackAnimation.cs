using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackAnimation : MonoBehaviour
{


    public float colliderRadius = 2.0f;
    public int attackDamage = 1;
    public Vector3 mira = new Vector3(0, 2, 0);
    public float cooldown;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        GetMouseInput();
    }

    void GetMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            StartCoroutine(Attack());

    
        }



    }





    IEnumerator Attack()
    {

        anim.SetTrigger("punch");
        yield return new WaitForSeconds(4f);
        
        GetEnemyList();
        yield return new WaitForSeconds(4f);
        //anim.SetBool("punch", false);

    }


    void GetEnemyList()
    {
        foreach (Collider c in Physics.OverlapSphere((transform.position + transform.forward * colliderRadius), colliderRadius))
        {     
            if (c.gameObject.CompareTag("Enemy"))
            {
                
                c.GetComponent<HealthEnemyContronller>().TakeDamage(attackDamage);
            }

        }

    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + transform.forward +  mira, colliderRadius);
    }




}
