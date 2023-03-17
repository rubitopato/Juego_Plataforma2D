using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerRespawn>().ReachedCheckPoint(gameObject.transform.position.x, gameObject.transform.position.y);
            gameObject.GetComponent<Animator>().enabled = true;
        }
    }
}
