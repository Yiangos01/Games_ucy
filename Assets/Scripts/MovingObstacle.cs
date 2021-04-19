using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public Vector3 dir = Vector3.zero;
    public float speed = 50f;
    public float pos;
    // Start is called before the first frame update
    void Start()
    {
       // pos = transform.right;
    }

    // Update is called once per frame
    void Update()
    {
        Camera cam = Camera.main;
        Vector3 rig = cam.transform.right;
        rig.y = 0;
        rig.Normalize();
        //transform.position = transform.position + Time.deltaTime * dir*speed;Mathf.PingPong(Time.time * 0.5f, 0.5f)
        transform.position = transform.position + rig*Time.deltaTime * speed;
    }
}
