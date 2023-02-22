using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CombatEnemy : MonoBehaviour
{
    [Header("Atributtes")]

    
    public float totalHealth;

    public int attackDamage;

    public float movementSpeed;

    public float lookRadius;

    public float colliderRadius = 2f;

    private Animator anim;
    private CapsuleCollider capsule;
    private NavMeshAgent agent;


    private Transform player;


    private bool attacking;
    public bool walking;
    private bool waitFor;
    public bool vivo;


    public Collision collision;


    void Start()
    {

        colliderRadius = 2f;
        anim = GetComponent<Animator>();
        capsule = GetComponent<CapsuleCollider>();
        agent = GetComponent<NavMeshAgent>();

        player = GameObject.FindGameObjectWithTag("Player").transform;
        vivo = true;
    }

    void Update()
    {

        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= lookRadius && vivo)
        {
            //personagem está no raio de ação
            agent.isStopped = false;
            //anim.SetBool("Walk Forward", true);


            if (!attacking)
            {
                agent.SetDestination(player.position);
                anim.SetBool("Walk Forward", true);
                walking = true;

            }


            if (distance <= agent.stoppingDistance)
            {
                //personagem entrou no raio de ataque
                StartCoroutine("Attack");
                
            }

            else
            {
                //saiu o raio de ataque
                attacking = false;
            }

        }
        else
        {
            //personagem esta fora do raio de ação
            agent.isStopped = true;
            anim.SetBool("Walk Forward", false);
            walking = false;
            attacking = false;
            

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

            agent.isStopped = true;

            anim.SetBool("Walk Forward", false);
            anim.SetBool("Bite Attack", true);


            yield return new WaitForSeconds(1.1f);

            GetPlayer();
            //yield return new WaitForSeconds(1f);
            waitFor = false;
        }

    }

    void GetPlayer()
    {

        foreach (Collider c in Physics.OverlapSphere((transform.position + transform.forward * colliderRadius), colliderRadius))
        {

            if (c.gameObject.CompareTag("Player"))
            {
                //APLICAR DANO NO PLAYER
                Debug.Log("bateu");
                
                c.GetComponent<HealthController>().TakeDamage(attackDamage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}