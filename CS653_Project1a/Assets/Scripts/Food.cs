using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public float rotSpeed = 50.0f;
    private float posy;
    
    // Start is called before the first frame update
    void Start()
    {
        posy = transform.position.y;

    }
   

    // Update is called once per frame
    void Update()
    {
       transform.Rotate(Vector3.up * Time.deltaTime * rotSpeed);
        transform.position = new Vector3(transform.position.x,Mathf.PingPong(Time.time * 0.5f, 0.5f) + posy, transform.position.z);
    }
}
