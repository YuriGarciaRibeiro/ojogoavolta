using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoedaController : MonoBehaviour
{
    public float spinSpeed = 180f;
    public float alturaY;
    public float delay;
    private float initY;


    void OnTriggerEnter(Collider col) // receber o que ele ta colidando
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log("Moeda");
            Destroy(gameObject); // col.gameobject vai destruir o que ele ta colidindo
        }

    }

    private void Start()
    {
        initY= transform.position.y;
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, spinSpeed* Time.deltaTime);


        if (transform.position.y >= 1.6f)
        {
            transform.position = new Vector2 (transform.position.x,1.6f);
            alturaY = -alturaY;
        }
        else if (transform.position.y <= initY)
        {
            transform.position = new Vector2(transform.position.x, initY);
            alturaY = -alturaY;
        }
        StartCoroutine(Espera(delay));
    }

    IEnumerator Espera(float delay)
    {
        yield return new WaitForSeconds(delay);
        transform.Translate(new Vector3(0, alturaY * Time.deltaTime, 0));
    }
}