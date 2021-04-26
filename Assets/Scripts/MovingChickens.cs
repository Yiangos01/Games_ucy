using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingChickens : MonoBehaviour
{
    public float speed;
    float hmove;
    float vmove;

    // Start is called before the first frame update
    void Start()
    {
         hmove= Random.Range(-0.5f,0.5f);
         vmove= Random.Range(0f,1f);
         speed = Random.Range(5.0f, 20.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Camera cam = Camera.main;
        Vector3 forward = cam.transform.forward;
        forward.y = 0;
        forward.Normalize();

        Vector3 right = cam.transform.right;
        right.y = 0;
        right.Normalize();
       
        Vector3 dir =  hmove* right -  forward;
      
        transform.position = transform.position + Time.deltaTime * speed * dir;
        transform.rotation = Quaternion.LookRotation(dir);
    }
}
