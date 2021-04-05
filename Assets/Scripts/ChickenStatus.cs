using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenStatus : MonoBehaviour
{
    [SerializeField] public int food = 0;
    [SerializeField] public int heart = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Food"))
        {
            Destroy(other.gameObject);
            food++;
            Debug.Log("food " + food);
        }
    }
    private void OnCollisionEnter(Collision collision)

    {
        
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            
            heart--; 
            Debug.Log("heart " + heart);
            if(heart == 0)
                Destroy(gameObject);
           
        }


    }
    // Update is called once per frame
    void Update()
    {
        
        
    }
}
