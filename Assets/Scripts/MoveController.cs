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

    public float speed;
    private CharacterController character;

    public float smoothRotTime;
    private float turnSmoothVelocity;
    Vector3 moveDirection;

    private Transform cameraPrincipal;
    public float gravity;





    public float groundCheckDistance = 0.1f;
    public LayerMask groundLayer;


    //public float horizontalMin, horizontalMax, verticalMin, verticalMax;

    [SerializeField] private GameObject posicaoInicial;

    public float jump;



    void MoveCamera() {
        mouseY += Input.GetAxis("Mouse Y"); //* sense * Time.deltaTime;
        mouseX += Input.GetAxis("Mouse X"); //* sense * Time.deltaTime;

        mouseY = Mathf.Clamp(mouseY, camMin, camMax);

        cam.transform.eulerAngles = new Vector3(-mouseY, mouseX, 0);

        this.transform.eulerAngles = new Vector3(0, mouseX, 0);
    }

    private void LockMouse(bool isLocked)
    {
        Cursor.visible = isLocked;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Jump() {


        if (Input.GetKey(KeyCode.Space) && onGround && !AnimatorIsPlaying("jump"))
        {
            //print("test1");
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

        character = GetComponent<CharacterController>();

        rb = GetComponent<Rigidbody>();

        cam = Camera.main;

        this.transform.position = posicaoInicial.transform.position;

        LockMouse(true);

        cam.transform.eulerAngles = Vector3.zero;

        animator = GetComponent<Animator>();

        speed = 5f;

        cameraPrincipal = Camera.main.transform;

    }



    //IEnumerator animationTime(int i, float f)
    //{

    //}

    void Update()
    {


        Move();





        MoveCamera();

        //cam.transform.position = transform.GetChild(0).position;

        //Jump();

        //onGround = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);

    }

    private void Move()
    {


        if (character.isGrounded)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 direction = new(horizontal, 0f, vertical);

            if (direction.magnitude > 0)
            {
                controller.SetBool("idle", false);
                float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraPrincipal.eulerAngles.y;
                float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, angle, ref turnSmoothVelocity, smoothRotTime);

                transform.rotation = Quaternion.Euler(0f, smoothAngle, 0f);

                moveDirection = Quaternion.Euler(0f, angle, 0f) * Vector3.forward * speed;

                controller.SetBool("walk", true);

                //GetComponent<PlayerAttackAnimation>().canAttack = false;
            }

            else { 
            
                controller.SetBool("idle", true);
                controller.SetBool("walk", false);
                moveDirection = Vector3.zero;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;


        character.Move(moveDirection * Time.deltaTime);
    }
}
