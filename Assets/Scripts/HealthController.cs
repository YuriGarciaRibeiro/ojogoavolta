using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    private GameObject heart;
    private GameObject HalfHeart;

    [SerializeField]
    [Header("Localização do coração")]
    private Transform heartLocation;


    public int healthAct;
    public int healthMax = 20;
    public int vidaAntes;

    public List<GameObject> heartList= new List<GameObject>();

    
    void TakeDamage(int damage) {

        vidaAntes = healthAct;
        healthAct -= damage;

        
        if (healthAct <= 0)
        {
            print("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            healthAct = 0;
            print(healthAct);
            //Dead();
            for (int i = 1; i <= heartList.Count ; i += 2)
            {
                GameObject coracao = heartList[heartList.Count - 1];
                heartList.Remove(heartList[heartList.Count - 1]);
                Destroy(coracao);

            }

        }
        else
        {

            if (damage % 2 == 0)
            {


                if (healthAct % 2 == 0)
                {
                    print("teste1");
                    for (int i = 1; i <= (vidaAntes - healthAct); i += 2)
                    {
                        GameObject coracao = heartList[heartList.Count - 1];
                        heartList.Remove(heartList[heartList.Count - 1]);
                        Destroy(coracao);

                    }
                }
                else
                {
                    print("teste2");
                    for (int i = 1; i <= (vidaAntes - healthAct) / 2; i += 2)
                    {
                        GameObject coracao = heartList[heartList.Count - 1];
                        heartList.Remove(heartList[heartList.Count - 1]);
                        Destroy(coracao);

                    }
                    GameObject coracao2 = heartList[heartList.Count - 1];
                    heartList.Remove(heartList[heartList.Count - 1]);
                    Destroy(coracao2);
                    GameObject halfheart = Instantiate(this.HalfHeart, heartLocation);
                    heartList.Add(halfheart);
                }
            }
            else
            {


                if (healthAct % 2 == 0)
                {

                    if (vidaAntes - healthAct == 1)
                    {
                        print("teste3");
                        GameObject coracao = heartList[heartList.Count - 1];
                        heartList.Remove(heartList[heartList.Count - 1]);
                        Destroy(coracao);

                    }
                    else
                    {
                        print("teste4");
                        for (int i = 1; i <= (vidaAntes - healthAct) / 2; i += 2)
                        {
                            GameObject coracao = heartList[heartList.Count - 1];
                            heartList.Remove(heartList[heartList.Count - 1]);
                            Destroy(coracao);
                        }
                        GameObject coracao2 = heartList[heartList.Count - 1];
                        heartList.Remove(heartList[heartList.Count - 1]);
                        Destroy(coracao2);

                    }
                }
                else
                {
                    if (vidaAntes - healthAct == 1)
                    {
                        print("teste5");
                        GameObject coracao2 = heartList[heartList.Count - 1];
                        heartList.Remove(heartList[heartList.Count - 1]);
                        Destroy(coracao2);
                        GameObject halfheart = Instantiate(this.HalfHeart, heartLocation);
                        heartList.Add(halfheart);
                    }
                    else
                    {
                        print("teste6");
                        for (int i = 1; i <= (vidaAntes - healthAct) / 2; i += 2)
                        {
                            GameObject coracao = heartList[heartList.Count - 1];
                            heartList.Remove(heartList[heartList.Count - 1]);
                            Destroy(coracao);
                        }
                        GameObject coracao2 = heartList[heartList.Count - 1];
                        heartList.Remove(heartList[heartList.Count - 1]);
                        Destroy(coracao2);
                        GameObject halfheart = Instantiate(this.HalfHeart, heartLocation);
                        heartList.Add(halfheart);
                    }

                }
            }

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
            
            for (int i = 1; i <= healthMax; i+=2) {
                GameObject heart = Instantiate(this.heart, heartLocation);
                heartList.Add(heart);
            }
            healthAct = healthMax;
        }
    
    }


    private void Dead()
    {
        Destroy(gameObject);
    }

    void Start()
    {
        
        heart = Resources.Load("heart") as GameObject;
        HalfHeart = Resources.Load("HalfHeart") as GameObject;
        AddHeart();
    }

    
    void Update()
    {
        
    }








}
