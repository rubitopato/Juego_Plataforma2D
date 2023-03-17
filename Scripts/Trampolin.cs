using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolin : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.transform.CompareTag("Player"))
            {
                PlayerMove.canDoubleJump = true; //esto es en ordenador, cambiar para movil
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.gameObject.GetComponent<Rigidbody2D>().velocity.x, 4.4f);
                gameObject.GetComponent<Animator>().SetBool("Touch", true);
            }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
            if (collision.transform.CompareTag("Player"))
            {
                gameObject.GetComponent<Animator>().SetBool("Touch", false);
            }
        
    }
}
