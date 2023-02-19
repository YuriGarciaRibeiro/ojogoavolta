using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackAnimation : MonoBehaviour
{


    public float colliderRadius = 2.0f;
    public int attackDamage = 1;
    public Vector3 mira = new Vector3(0, 2, 0);
    public float cooldown = 0.5f;
    public bool canAttack = true;


    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        GetMouseInput();
    }

    public void GetMouseInput()
    {
        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            StartCoroutine(Attack());
        }
    }





    IEnumerator Attack()
    {
            canAttack = true;
            anim.SetTrigger("punch");
            canAttack = false;
            yield return new WaitForSeconds(0.8f);
            GetEnemyList();
            yield return new WaitForSeconds(cooldown);
            canAttack = true;

       

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
