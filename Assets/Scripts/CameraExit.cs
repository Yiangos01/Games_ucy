using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraExit : MonoBehaviour
{
    
    void OnTriggerExit(Collider other)
    {
       
        if (other.gameObject.tag == "CameraCollider")//If camera exits
        {
            Destroy(gameObject.transform.parent.gameObject, 1);
        }

    }
    
}
