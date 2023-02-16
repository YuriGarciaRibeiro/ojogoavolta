using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PlayerCombatControler : MonoBehaviour
{
    [Header("Atributtes")]

    
    public bool CanAttack = true;
    public float AttackCoolDown = 1.0f;
    public Animator controller;
    public float colliderRadius = 2f;
    public int attackDamage = 2;
    private bool waitFor;
    private bool attacking;
    private bool walking;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (CanAttack)
            {
                StartCoroutine("Attack");
            }
        }
    }

    

    IEnumerator Attack()
    {

        //yield return new WaitForSeconds(0.4f);
        if (!waitFor)
        {
            waitFor = true;
            attacking = true;
            walking = false;
            controller.SetBool("punch", true);
            yield return new WaitForSeconds(AttackCoolDown);
            GetPlayer();
            controller.SetBool("punch", true);
            //yield return new WaitForSeconds(1f);
            waitFor = false;
        }

    }

    void GetPlayer()
    {

        foreach (Collider c in Physics.OverlapSphere((transform.position + transform.forward * colliderRadius), colliderRadius))
        {

            if (c.gameObject.CompareTag("Enemy"))
            {
                //APLICAR DANO NO PLAYER
                Debug.Log("bateu");
                c.GetComponent<HealthEnemyContronller>().TakeDamage(attackDamage);
            }
        }
    }







}
