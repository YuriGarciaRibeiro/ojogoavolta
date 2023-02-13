using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public float velocidade;

    public float deslocamentoVertical, deslocamentoHorizontal;

    private Camera cam;

    public float sense;

    private float mouseX, mouseY;

    public float camMin, camMax;

    public bool onGround;

    public int pontos = 0;

    private Rigidbody rb;

    public Animator controller;

    private Animator animator;





    public float groundCheckDistance = 0.1f;
    public LayerMask groundLayer;


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


        if (Input.GetKey(KeyCode.Space) && onGround && !AnimatorIsPlaying("jump"))
        {
            print("test1");
            rb.velocity = new Vector3(0, jump, 0);


        
            controller.SetBool("pulo", true);

            
       
        }
        else if (onGround && !AnimatorIsPlaying("jump"))
        {
            controller.SetBool("pulo", false);
        }
    }

    bool AnimatorIsPlaying()
    {
        return animator.GetCurrentAnimatorStateInfo(0).length >
               animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }

    bool AnimatorIsPlaying(string stateName)
    {
        return AnimatorIsPlaying() && animator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }





    void Start()
    {
        controller.SetBool("idle", true);


        rb = GetComponent<Rigidbody>();

        cam = Camera.main;

        this.transform.position = posicaoInicial.transform.position;

        LockMouse(true);

        cam.transform.eulerAngles = Vector3.zero;

        animator = GetComponent<Animator>();

    }



    //IEnumerator animationTime(int i, float f)
    //{

    //}

    void Update()
    {
        deslocamentoVertical = Input.GetAxis("Vertical") * velocidade;
        deslocamentoVertical *= Time.deltaTime;

        deslocamentoHorizontal = Input.GetAxis("Horizontal") * velocidade;
        deslocamentoHorizontal *= Time.deltaTime;
        //Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D
        // andar
        
        if (deslocamentoVertical > 0) {
            controller.SetBool("walk", true);
            controller.SetBool("idle", false);
        }
        else if (deslocamentoVertical < 0)
        {
            controller.SetBool("walkBack", true);
            controller.SetBool("idle", false);
        }
        else if(deslocamentoHorizontal == 0 && deslocamentoVertical == 0)
        {
            controller.SetBool("idle", true);
            controller.SetBool("walk", false);
            controller.SetBool("walkBack", false);
            controller.SetBool("run", false);
            controller.SetBool("pontadepe", false);
        }


        

        this.transform.Translate(deslocamentoHorizontal, 0, deslocamentoVertical);

        MoveCamera();

        cam.transform.position = transform.GetChild(0).position;

        Jump();



        onGround = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);


    }
}
