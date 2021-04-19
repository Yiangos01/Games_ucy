using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIshow : MonoBehaviour
{
    // Start is called before the first frame update
    //public  uiObject;
    GameObject uiObject;
    void Start()
    {
        GameObject[] uiObjects = GameObject.FindGameObjectsWithTag("finishText");
        uiObject = uiObjects[0];
    }

    void OnTriggerEnter(Collider player)
    {
        Debug.Log("On trigger");
        if (player.gameObject.tag == "Player")
        {
            Debug.Log("Inside if");
            uiObject.SetActive(true);
        }
    }


    // Update is called once per frame
    //void Update()
    //{
        
    //}
}
