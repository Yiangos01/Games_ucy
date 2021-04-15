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
    public List<int> pattern;
    public List<int> targetPattern;
    public GameObject Fruits;

    // Start is called before the first frame update
    void Start()
    {
        isHit = false;
        animator = transform.GetChild(0).gameObject.GetComponent<Animator>();
        chMv = GetComponent<ChickenMovement>();
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        createTargetPattern();
    }

    void createTargetPattern()
    {
        for (int i =0; i<6; i++)
        {
            int number = Random.Range(1, 8);
            targetPattern.Add(number);
        }
    }

    void updatePattern(string category)
    {
        Debug.Log(category.Split(char.Parse("("))[0]);
        category = category.Split(char.Parse("("))[0];
        int target_category = targetPattern[pattern.Count];

        if(string.Compare(category, "apple") == 0)
        {
            if (target_category==1)
            {
                pattern.Add(1);
            }
        }
        if (string.Compare(category, "banana") == 0)
        {
            if (target_category == 2)
            {
                pattern.Add(2);
            }
        }
        if (string.Compare(category, "carrot") == 0)
        {
            if (target_category == 3)
            {
                pattern.Add(3);
            }
        }
        if (string.Compare(category, "cherry") == 0)
        {
            if (target_category == 4)
            {
                pattern.Add(4);
            }
        }
        if (string.Compare(category, "grape") == 0)
        {
            if (target_category == 5)
            {
                pattern.Add(5);
            }
        }
        if (string.Compare(category, "pumpkin") == 0)
        {
            if (target_category == 6)
            {
                pattern.Add(6);
            }
        }
        if (string.Compare(category, "watermelon") == 0)
        {
            if (target_category == 7)
            {
                pattern.Add(7);
            }
        }
        if (pattern.Count == targetPattern.Count)
        {
            Debug.Log("Pattern completed");
            Debug.Log("Create new pattern");
            pattern.Clear();
            targetPattern.Clear();
            createTargetPattern();
        }
            
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Food"))
        {

            
            // Debug.Log(Fruits.Materials);
            Destroy(other.gameObject);
            updatePattern(other.gameObject.name);
            food++;
            //Debug.Log("food " + food);
           
        }

        if (other.gameObject.CompareTag("GoldenEgg"))
        {
            Destroy(other.gameObject);
            goldenEgg++;
            Debug.Log("Golden Egg " + goldenEgg);
            //Spawn the Barn if collected 2 golden Eggs (End Game Condition)
            if (goldenEgg == 2) {
                groundSpawner.SpawnBarn();
                // Display ending Animation
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
                // Game Over message - button to restart or go back to main menu
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
