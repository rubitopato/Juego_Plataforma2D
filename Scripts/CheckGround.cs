using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public static bool isGround; //static es para usarla en otro script
    

    private void OnTriggerEnter2D(Collider2D collision)//cuando entra en una geometria
    {
        if (collision.CompareTag("Ground"))
        {
            gameObject.transform.GetComponentInParent<Animator>().SetBool("Fall", false);
            isGround = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)//cuando sale de ella
    {
        if (collision.CompareTag("Ground"))
        {
            isGround = false;
        }
        
    }
}
