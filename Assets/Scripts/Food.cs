using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public float rotSpeed = 50.0f;
    public int category = -1;
    private float posy;

    // Start is called before the first frame update
    void Start()
    {
        posy = transform.position.y;
    }
   
    public int get_category()
    {
        return category;
    }

    // Update is called once per frame
    void Update()
    {
       transform.Rotate(Vector3.up * Time.deltaTime * rotSpeed);
       transform.position = new Vector3(transform.position.x,Mathf.PingPong(Time.time * 0.5f, 0.5f) + posy, transform.position.z);
    }

}
