using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
   
    public float speed;
    public Vector3 direction;
    Vector3 initialPos;
   
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(5.0f,15.0f);
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        //transform.position = transform.position + Time.deltaTime * dir*speed;Mathf.PingPong(Time.time * 0.5f, 0.5f)
       // transform.position = transform.position + direction*Time.deltaTime * speed;
        transform.position = new Vector3(direction.x *Mathf.PingPong(Time.time * speed, 28f) +initialPos.x-14f* direction.x, transform.position.y, direction.z * Mathf.PingPong(Time.time * speed, 28f) + initialPos.z-14f* direction.z);
       
    }
}
