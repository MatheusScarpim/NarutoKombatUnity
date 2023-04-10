using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moviment : MonoBehaviour
{

    [Header("Cronometro")]
    public float cronometrotempo;
    public float  TempoLimite;
    private bool AtivarCronometro;
    public float DelayAttack;
    public bool AtivarDelayAttack;
    public float TempoDelay;

    [Header("Attacks")]
    private  bool chuteAttack;
    private bool socoAttack;
    [Header("Moviment")]
    public float Speed;
    public float JumpForce;
    private Rigidbody2D rig;
    private bool IsJumping;
    private bool Canmove;
    [Header("Geral")]
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        socoAttack = true;
        Canmove = true;
        chuteAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Attack();
        Cronometro();
    }

    void Move()
    {
        if(Canmove)
        {
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            transform.position += movement * Time.deltaTime * Speed;
            if(Input.GetAxis("Horizontal") > 0)
            {
                anim.SetBool("run", true);
                anim.SetBool("walk", false);
                transform.eulerAngles = new Vector3(0f,0f,0f);
                socoAttack = false;   
            }

            if(Input.GetAxis("Horizontal") < 0)
            {
                anim.SetBool("run", true);
                anim.SetBool("walk", false);
                transform.eulerAngles = new Vector3(0f,180f,0f);
                socoAttack = false;
            }
        }

        if(Input.GetAxis("Horizontal") == 0)
        {
            anim.SetBool("run", false);
            anim.SetBool("walk", true);
            socoAttack = true;

        }
        
    }

    void Jump()
    {
            if(Input.GetButtonDown("Jump") && IsJumping == false)
            {
            rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            anim.SetBool("jump", true);
        }   
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            IsJumping = false;
            anim.SetBool("jump", false);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            IsJumping = true;
            socoAttack = false;
        }
    }

    void Attack()
    {
        if(socoAttack && IsJumping == false && AtivarDelayAttack == false)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("soco");
                IsJumping = true;
                anim.SetTrigger("soco");
                Canmove = false;
                AtivarCronometro = true;
                AtivarDelayAttack = true;
            }
        }

        if(chuteAttack && IsJumping == false && AtivarDelayAttack == false)
        { 
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("Chute");
                IsJumping = true;
                anim.SetTrigger("chute");
                Canmove = false;
                AtivarCronometro = true;
                AtivarDelayAttack = true;
            }
        }
    }

    void Cronometro()
    {
        if (AtivarCronometro)
        {
            cronometrotempo += Time.deltaTime;
            if (cronometrotempo >= TempoLimite)
            {

                IsJumping = false;
                Canmove = true;
                cronometrotempo = 0;
                AtivarCronometro = false;
            }
        }
        if (AtivarDelayAttack)
        {
            DelayAttack += Time.deltaTime;
            if (DelayAttack >= TempoDelay)
            {
                DelayAttack = 0;
                AtivarDelayAttack = false;
            }
        }
    }
}