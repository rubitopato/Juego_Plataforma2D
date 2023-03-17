using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfMovile : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        if (!player.GetComponent<PlayerMoveJoystick>().enabled)
        {
            gameObject.SetActive(false);
        }
    }

}
