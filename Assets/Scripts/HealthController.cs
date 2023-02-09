using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    private GameObject heart;

    [SerializeField]
    [Header("Localização do coração")]
    private Transform heartLocation;


    public int healthAct;
    public int healthMax = 20;

    public List<GameObject> heartList= new List<GameObject>();


    void TakeDamage(int damage) {
        healthAct -= damage;

        

        GameObject heart = heartList[heartList.Count - 1];
        heartList.Remove(heartList[heartList.Count - 1]);
        Destroy(heart);




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

    private void AddHeart ()
    {
        if (healthAct == 0) {
            
            for (int i = 1; i <= healthMax; i+=1) {
                GameObject heart = Instantiate(this.heart, heartLocation);
                heartList.Add(heart);
            }
            healthAct = healthMax;
        }
    
    }


    private void Dead()
    {
        
    }

    void Start()
    {
        
        heart = Resources.Load("heart") as GameObject;
        AddHeart();
    }

    
    void Update()
    {
        
    }








}
