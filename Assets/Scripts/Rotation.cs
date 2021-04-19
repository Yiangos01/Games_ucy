using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rotSpeed = 50.0f;
    private int dir;
    // Start is called before the first frame update
    void Start()
    {
          dir = Random.Range(0, 2);//Direction of rotation
    }

    // Update is called once per frame
    void Update()
    {
      
        if(dir<1)
            transform.Rotate(Vector3.up * Time.deltaTime * rotSpeed);
        else
            transform.Rotate(-Vector3.up * Time.deltaTime * rotSpeed);
    }
}
