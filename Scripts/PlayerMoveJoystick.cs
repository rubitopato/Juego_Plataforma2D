using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveJoystick : MonoBehaviour
{
    public float speed = 2;
    public float jumpSpeed = 4;
    public float doubleJumpSpeed = 3;
    private bool canDoubleJump;
    public Rigidbody2D rigid;

    public SpriteRenderer sprite;
    public Animator animator;
    public static float frogPosition = 0;
    public static float frogPositionY = 0;

    private float horizontalMove = 0;
    public Joystick joystick;
    public float runSpeedHorizontal=1.25f;


    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        frogPosition = gameObject.transform.position.x;
        frogPositionY = gameObject.transform.position.y;

        if (horizontalMove>0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("Run", true); //para cambiar el valor de un parametro del animator
        }
        else if (horizontalMove<0)
        {
            //sprite.flipX=true; con el spriteRenderer flipea la ranita
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }

        if (!CheckGround.isGround && animator.GetBool("Jump") == false)
        {
            animator.SetBool("Fall", true);
        }
    }


    void FixedUpdate()
    {
        horizontalMove = joystick.Horizontal * runSpeedHorizontal;//esto es la cantidad que mueves el joystick (el joystick)
        transform.position += new Vector3(horizontalMove, 0, 0) * Time.deltaTime * speed;

        if (rigid.velocity.y < 0)
        {
            animator.SetBool("DoubleJump", false);
            animator.SetBool("Jump", false);
        }
        if (rigid.velocity.y == 0)
        {
            canDoubleJump = true;
            animator.SetBool("Fall", false);
        }
    }
    public void Jump()
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
            if (canDoubleJump)
            {
                animator.SetBool("Run", false);
                animator.SetBool("DoubleJump", true);
                rigid.velocity = new Vector2(rigid.velocity.x, doubleJumpSpeed);
                canDoubleJump = false;
            }
        }
    }
}
