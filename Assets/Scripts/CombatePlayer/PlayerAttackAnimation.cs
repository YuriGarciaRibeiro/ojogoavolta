using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackAnimation : MonoBehaviour
{


    public float colliderRadius = 2.0f;
    public int attackDamage = 1;
    public Vector3 mira = new Vector3(0, 2, 0);




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
       // print("aquiuma");
        yield return new WaitForSeconds(1f);
        GetEnemyList();
        //print("aqui a outra");

    }


    void GetEnemyList()
    {
        foreach (Collider c in Physics.OverlapSphere((transform.position + transform.forward * colliderRadius), colliderRadius))
        {
            print("chegou no foreach");
            print(c.gameObject.tag);
            if (c.gameObject.CompareTag("Enemy"))
            {
                print("ta chegando aqui");
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
