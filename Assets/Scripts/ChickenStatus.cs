using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenStatus : MonoBehaviour
{
    [SerializeField] public int food = 0;
    [SerializeField] public int heart = 10;
    protected Animator animator;
    protected float timer = 2f;
    public bool isHit;
    protected ChickenMovement chMv;
    // Start is called before the first frame update
    void Start()
    {
        isHit = false;
        animator = transform.GetChild(0).gameObject.GetComponent<Animator>();
        chMv = GetComponent<ChickenMovement>();
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
            //Set hit animation
            
            
            
            if(heart == 0)
                Destroy(gameObject);
            isHit = true;
           // transform.GetChild(0).gameObject.transform.rotation = Quaternion.LookRotation(transform.forward+transform.right);
        }

        
    }
    // Update is called once per frame
    void Update()
    {

        if (isHit)
        {
            timer -= Time.deltaTime;
            if (timer >= 0f)
            {

                chMv.moveSpeed = 0.0f;
                animator.SetBool("IsHit", true);


            }
            
            else
            {
                animator.SetBool("IsHit", false);
                timer = 2f;
                isHit = false;
                chMv.moveSpeed = 30.0f;

            }
           
        }
      


    }
}
