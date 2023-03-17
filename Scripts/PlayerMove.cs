using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed=2;
    public float jumpSpeed = 4;
    public float doubleJumpSpeed = 3;
    public static bool canDoubleJump;
    public Rigidbody2D rigid;

    public bool saltoCargado;
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 1f;

    public SpriteRenderer sprite;
    public Animator animator;
    public static float frogPosition=0;
    public static float frogPositionY = 0;
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (CheckGround.isGround) 
            {
                canDoubleJump = true;
                animator.SetBool("Run", false);
                animator.SetBool("Jump", true);
                rigid.velocity = new Vector2(rigid.velocity.x, jumpSpeed);
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space) && canDoubleJump)
                {
                    animator.SetBool("Run", false);
                    animator.SetBool("DoubleJump", true);
                    rigid.velocity = new Vector2(rigid.velocity.x, doubleJumpSpeed);
                    canDoubleJump = false;
                }
            }

        }
        
        if (!CheckGround.isGround && animator.GetBool("Jump") == false)
        {
            animator.SetBool("Fall", true);
        }
    }


    void FixedUpdate()
    {
        
         frogPosition = gameObject.transform.position.x;
         frogPositionY = gameObject.transform.position.y;


        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("Run",true); //para cambiar el valor de un parametro del animator
            rigid.velocity = new Vector2(speed, rigid.velocity.y);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //sprite.flipX=true; con el spriteRenderer flipea la ranita
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetBool("Run", true);
            rigid.velocity = new Vector2(-speed, rigid.velocity.y);
            
        }
        else
        {
            rigid.velocity = new Vector2(0, rigid.velocity.y);
            animator.SetBool("Run", false);
        }
        
        
        if (saltoCargado)
        {
            if (rigid.velocity.y < 0)
            {
                animator.SetBool("DoubleJump", false);
                animator.SetBool("Jump", false);
                rigid.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;      //up == (0,1)
            }

            if (rigid.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
            {
                rigid.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }
            if (rigid.velocity.y == 0)
            {
                canDoubleJump = true;
                animator.SetBool("Fall", false);
            }
        }
        




    }
}
