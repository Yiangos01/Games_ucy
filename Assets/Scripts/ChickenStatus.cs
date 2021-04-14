using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenStatus : MonoBehaviour
{
    [SerializeField] public int food = 0;
    [SerializeField] public int heart = 10;
    [SerializeField] public int goldenEgg = 0;
    GroundSpawner groundSpawner;
    protected Animator animator;
    public bool isHit;
    protected ChickenMovement chMv;

    // Start is called before the first frame update
    void Start()
    {
        isHit = false;
        animator = transform.GetChild(0).gameObject.GetComponent<Animator>();
        chMv = GetComponent<ChickenMovement>();
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Food"))
        {
            Destroy(other.gameObject);
            food++;
            Debug.Log("food " + food);
           
        }

        if (other.gameObject.CompareTag("GoldenEgg"))
        {
            Destroy(other.gameObject);
            goldenEgg++;
            Debug.Log("Golden Egg " + goldenEgg);
            //Spawn the Barn if collected 2 golden Eggs
            if (goldenEgg == 2) {
                groundSpawner.SpawnBarn();
            }

        }
        if (other.gameObject.CompareTag("Barn"))
        {
            Destroy(other.gameObject);
            //SpawnChickens();

        }
        if (other.gameObject.CompareTag("Wave"))
        {
            Destroy(other.gameObject);
        }


    }
    private void OnCollisionEnter(Collision collision)

    {

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            heart--;
            Debug.Log("heart " + heart);
            if (heart == 0)
                Destroy(gameObject); 
            //Set hit animation
            animator.SetTrigger("IsHit");
            Destroy(collision.gameObject,1.8f);//Destroy object after a while
            
        }
        
        
    }
    // Update is called once per frame
    void Update()
    {
        //Check If the Dizzy animation is playing-if it's playing then set isHit = true
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Armature|Dizzy"))
            isHit = true;
        else
            isHit = false;//Dizzy animation has stopped playing
      

    }
}
