using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FruitManager : MonoBehaviour
{
    public Canvas levelCleared;
    public GameObject transition;
    public void Update()
    {
        AllFruitsCollected();
    }
    public void AllFruitsCollected()
    {
        if (gameObject.transform.childCount == 0)
        {
            levelCleared.gameObject.SetActive(true);
            Invoke("CallingAnimation", 0.5f);
            Invoke("ChangeScene", 1.4f);
            
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void CallingAnimation()
    {
        transition.SetActive(true);
    }
}
