using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class CoinsCounter : MonoBehaviour
{

    public TextMeshProUGUI text;
    public int pontos;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "Pontos : " + pontos;
    }


    public void SetText(int pontos)
    {
        text.text = "Pontos : " + pontos;
    }

    // Update is called once per frame
    void Update()
    {
       
    }





}
