using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public float velocidade;

    public float deslocamentoVertical, deslocamentoHorizontal;

    private Camera cam;

    public float sense;

    private float mouseX, mouseY;

    public float camMin, camMax;

    private Rigidbody rb;

    //public float horizontalMin, horizontalMax, verticalMin, verticalMax;

    [SerializeField]private GameObject posicaoInicial;

    public float jump;



    void MoveCamera() {
        mouseY += Input.GetAxis("Mouse Y"); //* sense * Time.deltaTime;
        mouseX += Input.GetAxis("Mouse X"); //* sense * Time.deltaTime;

        mouseY = Mathf.Clamp(mouseY, camMin, camMax);

        cam.transform.eulerAngles = new Vector3(-mouseY, mouseX, 0 );

        this.transform.eulerAngles = new Vector3(0,mouseX, 0);
    }

    private void LockMouse(bool isLocked)
    {
        Cursor.visible= isLocked;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Jump() {
        if (Input.GetKey(KeyCode.Space)) {
            rb.velocity = new Vector3(0, jump, 0);
        }

        
    }




    void Start()
    {
        rb = GetComponent<Rigidbody>();

        cam = Camera.main;

        this.transform.position = posicaoInicial.transform.position;

        LockMouse(true);

        cam.transform.eulerAngles = Vector3.zero;
    }


    void Update()
    {
        deslocamentoVertical = Input.GetAxis("Vertical") * velocidade;
        deslocamentoVertical *= Time.deltaTime;

        deslocamentoHorizontal = Input.GetAxis("Horizontal") * velocidade;
        deslocamentoHorizontal *= Time.deltaTime;

        

        

        this.transform.Translate(deslocamentoHorizontal, 0, deslocamentoVertical);

        MoveCamera();

        cam.transform.position = transform.GetChild(0).position;

        Jump();

    }
}
