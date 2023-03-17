using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitRecollected : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            FindObjectOfType<FruitManager>().AllFruitsCollected(); //find objectoftype busca un objeto con este script y llama al metodo allFruits
            Destroy(gameObject, 0.5f); //destruye este gameObject en despues de 0.5s
        }
    }
}
