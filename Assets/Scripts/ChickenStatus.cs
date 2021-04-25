using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenStatus : MonoBehaviour
{

    [SerializeField] public int food = 0;
    [SerializeField] public int heart = 4;
    public int maxHeart = 8;
    [SerializeField] public int goldenEgg = 0;
    GroundSpawner groundSpawner;
    protected Animator animator;
    public bool isHit;
    protected ChickenMovement chMv;
    public List<int> pattern;
    // public List<int> targetPattern;
    // public List<int> targetPatternJump;
    public List<int> targetPatternStrength;
    //public GameObject Fruits;
    //public GameObject obstaclesPrefab;
    public bool strengthMode = false; //Is chicken in strength mode
   // public bool jumpMode = false; //Is chicken in jump mode
    public ParticleSystem particles;
    public float strengthDuration;
    float strStart;

    public GameObject chickenBody;
    public GameObject chickenWings;
    public GameObject chickenThigs;
    //public GameObject uiFinish;
    public Color strengthColor;
  //  public Color jumpColor;
    private Color originalColor;
    SkinnedMeshRenderer chk_rendererBD;
    SkinnedMeshRenderer chk_rendererWG;
    SkinnedMeshRenderer chk_rendererTH;
    SpawnEffect strengthEffect;
    public int patternSize;
    public GameObject gameOverText;
    public AudioSource foodSound;
    public AudioSource eggSound;
    public AudioSource hitObstacleSound;
    public AudioSource breakObstacleSound;
    public AudioSource gameOverSound;
    public AudioSource winSound;
    public AudioSource powerUpSound;

    public int eggMax = 0;
    public AudioSource potionSound;
    public AudioSource dizzySound;
    public int counterEggSpawn=0;

    // Start is called before the first frame update
    void Start()
    {
        isHit = false;
        animator = transform.GetChild(0).gameObject.GetComponent<Animator>();
        chMv = GetComponent<ChickenMovement>();
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        strengthEffect = transform.GetChild(1).gameObject.GetComponent<SpawnEffect>();
       
        
        createTargetPatternStrength();
        // createTargetPatternJump();

        // Access chicken's body color
        chk_rendererBD = chickenBody.GetComponent<SkinnedMeshRenderer>();
        chk_rendererWG = chickenWings.GetComponent<SkinnedMeshRenderer>();
        chk_rendererTH = chickenThigs.GetComponent<SkinnedMeshRenderer>();
        originalColor = chk_rendererBD.material.color;



    }

    void createTargetPatternStrength()
    {
        for (int i =0; i<patternSize; i++)
        {
            int number = Random.Range(1, 8);
            targetPatternStrength.Add(number);
        }
    }

/*    void createTargetPatternJump()
    {
        for (int i = 0; i < patternSize; i++)
        {
            int number = Random.Range(1, 8);
            targetPatternJump.Add(number);
        }
    }
*/

    /*void updatePatternJump(string category)
    {
        if (!strengthMode)
        {
            Debug.Log(category.Split(char.Parse("("))[0]);
            category = category.Split(char.Parse("("))[0];
            int target_category = targetPatternJump[pattern.Count];

            if (string.Compare(category, "apple") == 0)
            {
                if (target_category == 1)
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
            if (pattern.Count == targetPatternJump.Count)
            {
                strStart = Time.time;
                jumpMode = true;
                // chicken_move.jumpForce = 35.0f;
                // Play power up sound
                powerUpSound.Play();
                // Change Color
                
                chk_rendererBD.material.color = jumpColor;
                chk_rendererWG.material.color = jumpColor;
                chk_rendererTH.material.color = jumpColor;

                strengthEffect.enabled = true;
                strengthEffect.spawnEffectTime = strengthDuration;
                strengthEffect.pause = 0.5f;
                
                Debug.Log("Pattern completed");
                Debug.Log("Create new pattern");
                pattern.Clear();
                targetPatternJump.Clear();
                createTargetPatternJump();
            }
        }
    }*/

    void updatePatternStrength(string category)
    {
        if (!strengthMode)
        {
            // Debug.Log(category.Split(char.Parse("("))[0]);
            category = category.Split(char.Parse("("))[0];
            int target_category = targetPatternStrength[pattern.Count];

            if (string.Compare(category, "apple") == 0)
            {
                if (target_category == 1)
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
            if (pattern.Count == targetPatternStrength.Count)
            {
                strStart = Time.time;
                strengthMode = true;
                // Play power up sound
                powerUpSound.Play();
                // Change Color
                chk_rendererBD.material.color = strengthColor;
                chk_rendererWG.material.color = strengthColor;
                chk_rendererTH.material.color = strengthColor;
                
                strengthEffect.enabled = true;
                strengthEffect.spawnEffectTime = strengthDuration;
                strengthEffect.pause = 0.5f;
                Debug.Log("Pattern completed");
                Debug.Log("Create new pattern");
                pattern.Clear();
                targetPatternStrength.Clear();
                createTargetPatternStrength();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Food"))
        {

            // Play food sound
            foodSound.Play();  // plays sound when collided.

            Destroy(other.gameObject);
            updatePatternStrength(other.gameObject.name);
            // updatePatternJump(other.gameObject.name);
            food++;
            //Debug.Log("food " + food);

        }

        if (other.gameObject.CompareTag("GoldenEgg"))
        {
            
                Destroy(other.gameObject);
                goldenEgg++;
                Debug.Log("Golden Egg " + goldenEgg);
                eggSound.Play();
                //Spawn the Barn if collected 2 golden Eggs (End Game Condition)

                if (goldenEgg == eggMax)
                {
                    // GroundSpawner.IsBarn = true;
                    groundSpawner.SpawnBarn();
                    // Display ending Animation
                }
            

        }
        if (other.gameObject.CompareTag("Barn"))
        {

            winSound.Play();
            groundSpawner.SpawnChickens();

        }
        if (other.gameObject.CompareTag("Potion"))
        {
            potionSound.Play();
            Destroy(other.gameObject);
            if(heart<maxHeart)
                heart++;

        }
        

        
    }
   

    //Function for blinking the object when hit a moving object
    private IEnumerator Blink()
    {
            transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
            yield return new WaitForSeconds(0.2f);
            transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
            yield return new WaitForSeconds(0.2f);
            transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
            yield return new WaitForSeconds(0.2f);
    }
   
    private void OnCollisionEnter(Collision collision)

    {

        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("GoldenEggCrate"))
        {
            if (!strengthMode)
            {
                heart--;
                // hit on obstacle sound
                hitObstacleSound.Play();
                Debug.Log("heart " + heart);
                if (heart <= 0)
                {
                    // Game Over message - button to restart or go back to main menu
                    // Play game over music
                    
                    gameOverText.SetActive(true);
                    gameOverSound.Play(); 
                   
                    Destroy(gameObject);
                   
                    
                }
                //Set hit animation
               
                animator.SetTrigger("IsHit");
                
                Destroy(collision.gameObject, 1.8f);//Destroy object after a while
            }
            else {//If in strength mode
                // Play break obsatcle sound
                breakObstacleSound.Play();
                //Break Simulation
                particles.transform.position = collision.gameObject.transform.position;
                particles.transform.rotation = Quaternion.LookRotation(-chMv.transform.right);
                particles.Play();//Play Particle Destruction
                Destroy(collision.gameObject);//Object dissappears
                food = food + 10;
                if (collision.gameObject.CompareTag("GoldenEggCrate")) {//If is the crate then collect egg as well
                    goldenEgg++;
                    // Play egg sound
                    eggSound.Play();
                    if (goldenEgg == eggMax)
                    { 
                        groundSpawner.SpawnBarn();
                        
                    }
                }
            }

            
        }
        if (collision.gameObject.CompareTag("RotatingObstacle"))//The object blinks-flickers when hit moving objects
        {
            if (!strengthMode)
            {
                hitObstacleSound.Play();
                heart--;
                StartCoroutine(Blink()); 
                if (heart <= 0)
                {
                    // Game Over message - button to restart or go back to main menu
                    // Play game over music

                    gameOverText.SetActive(true);
                    gameOverSound.Play();

                    Destroy(gameObject);


                }
            }


            else
            {//If in strength mode
                breakObstacleSound.Play();
                particles.transform.position = collision.gameObject.transform.position;
                particles.transform.rotation = Quaternion.LookRotation(-chMv.transform.right);
                particles.Play();//Play Particle Destruction
                Destroy(collision.gameObject);//Object dissappears
            }
        }
        if (collision.gameObject.CompareTag("OutOfTrack"))
        {
            gameOverText.SetActive(true);
            gameOverSound.Play();
            Destroy(gameObject);
            heart = 0;
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
      
        // If strength expire tranform chicken to its original form
        if (Time.time - strStart > strengthDuration && strengthMode) {
   
            StartCoroutine(Blink());//Blink to show that your strength mode is ending
            strengthMode = false;
            chk_rendererBD.material.color = originalColor;
            chk_rendererWG.material.color = originalColor;
            chk_rendererTH.material.color = originalColor;
            strengthEffect.enabled = false;
        }

      //  if (Time.time - strStart > strengthDuration && jumpMode)
       // {

         //   StartCoroutine(Blink());//Blink to show that your strength mode is ending
           // jumpMode = false;
           // chk_rendererBD.material.color = originalColor;
           // chk_rendererWG.material.color = originalColor;
           // chk_rendererTH.material.color = originalColor;
            //strengthEffect.enabled = false;
        //}

    }
}
