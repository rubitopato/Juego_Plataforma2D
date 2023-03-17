using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLevel3 : MonoBehaviour
{
    
    void FixedUpdate()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        gameObject.transform.position = new Vector3(PlayerMoveJoystick.frogPosition, gameObject.transform.position.y, gameObject.transform.position.z);
        
    }
}
