using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    private float spawnPositionX, spawnPositionY;
    //public Animator animator; tal y como lo hago no me hace falta
    void Start()
    {
        if (PlayerPrefs.GetFloat("spawnPositionX") != 0)
        {
            gameObject.transform.position = new Vector2(PlayerPrefs.GetFloat("spawnPositionX"), PlayerPrefs.GetFloat("spawnPositionY"));
        }
    }

    public void ReachedCheckPoint(float x,float y)
    {
        PlayerPrefs.SetFloat("spawnPositionX",x);
        PlayerPrefs.SetFloat("spawnPositionY", y);
    }

    public void PlayerDamaged()
    {
        gameObject.GetComponent<Animator>().SetBool("Hit", true); //animator.Play("Hit") to carry hit animation
        Invoke("ReloadScene", 0.5f); //lo hago asi para poder poner un delay
    }

    void ReloadScene()
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("SoyMarcos"))
        {
            FindObjectOfType<Vidas>().OneLifeLess();
        }
        if (PlayerPrefs.GetInt("Vidas") == 0)
        {
            SceneManager.LoadScene("Derrota");
        }

        else 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); //relodear scene
        }
        
    }
}
