using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    public GameObject obstaclesPrefab;
    public GameObject treesPrefab;
    public GameObject fruitsPrefab;
    public GameObject goldenEggPrefab;
    public GameObject potionPrefab;
    float obstacle_pos_x;
    float obstacle_pos_y;
    float obstacle_pos_z;
    public float threshold_dist;

    // Start is called before the first frame update
    void Start()
    {
     
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>(); 
        if(!groundSpawner.isStart)//At the start of the game don't spawn obstacles
            SpawnObstacle();
        //Always spawn decor and fruits
        SpawnTrees();
        SpawnFruits();
        //Spawn eggs less frequent-0.33 chance
        int frequencyEgg = Random.Range(0, 10);
        int frequencyPotion = Random.Range(0, 20);
        if (frequencyEgg<1)
            SpawnGoldenEggs();
        if (frequencyPotion <1)
            SpawnPotion();
    }

    void OnTriggerExit (Collider other)
    {
        
       
        if(other.gameObject.tag == "Player")//If player exits
            groundSpawner.SpawnTile();
        if (other.gameObject.tag == "CameraCollider")//If camera exits
        {      
            Debug.Log("Camera has left");
            Destroy(gameObject, 1);
        }
        
           
    }
    
    // Update is called once per frame
    //void Update(){}

   
    void SpawnTrees() { 
        // Choose random decor to fill decor positions
        // 1
        Transform DecorPoint = transform.GetChild(4).transform;
        int decorType = Random.Range(0, 9);
        Instantiate(treesPrefab.transform.GetChild(decorType).gameObject, DecorPoint.position, Quaternion.identity, transform);
        // 2
        DecorPoint = transform.GetChild(5).transform;
        decorType = Random.Range(0, 9);
        Instantiate(treesPrefab.transform.GetChild(decorType).gameObject, DecorPoint.position, Quaternion.identity, transform);
        // 3
        DecorPoint = transform.GetChild(6).transform;
        decorType = Random.Range(0, 9);
        Instantiate(treesPrefab.transform.GetChild(decorType).gameObject, DecorPoint.position, Quaternion.identity, transform);
        // 4
        DecorPoint = transform.GetChild(7).transform;
        decorType = Random.Range(0, 9);
        Instantiate(treesPrefab.transform.GetChild(decorType).gameObject, DecorPoint.position, Quaternion.identity, transform);
    }
    void SpawnFruits() {
        // Choose fruit type
        
        float z;
        float x;
        float y;
        int fruitType = Random.Range(0, 7);
        // Choose a random point to spawn fruit
        int fruitOffset = Random.Range(-16, 16);
        int fruitOffsetY = Random.Range(0, 5);
        Transform fruitPoint = transform.GetChild(8).transform;
        z = fruitPoint.position.z;
        z = z + fruitOffset;
        x = fruitPoint.position.x;
        x = x - fruitOffset;
        y = fruitPoint.position.y;
        y = y + fruitOffsetY;
        Vector3 fruitPosition = new Vector3(x, y, z);

        // Avoid Collision with obstacles
        float diff_x;
        diff_x = Mathf.Abs(Mathf.Abs(obstacle_pos_x) - Mathf.Abs(x)); 
        if (diff_x > threshold_dist)
        {
            Instantiate(fruitsPrefab.transform.GetChild(fruitType).gameObject, fruitPosition, Quaternion.identity, transform);
            return;
        }
        
        float diff_y;
        diff_y = Mathf.Abs(Mathf.Abs(obstacle_pos_y) - Mathf.Abs(y));
        if (diff_y > threshold_dist)
        {
            Instantiate(fruitsPrefab.transform.GetChild(fruitType).gameObject, fruitPosition, Quaternion.identity, transform);
            return;
        }
        
        float diff_z;
        diff_z = Mathf.Abs(Mathf.Abs(obstacle_pos_z) - Mathf.Abs(z));
        if (diff_z > threshold_dist)
        {
            Instantiate(fruitsPrefab.transform.GetChild(fruitType).gameObject, fruitPosition, Quaternion.identity, transform);
            return;
        }

    }
    void SpawnPotion() {
        float z;
        float x;
        float y;
        // Choose a random point to spawn fruit
        int potionOffset = Random.Range(-16, 16);
        int potionOffsetY = Random.Range(0, 5);
        Transform potionPoint = transform.GetChild(10).transform;
        z = potionPoint.position.z;
        z = z + potionOffset;
        x = potionPoint.position.x;
        x = x - potionOffset;
        y = potionPoint.position.y;
        y = y + potionOffsetY;

        Vector3 potionPosition = new Vector3(x, y, z);

        // Avoid Collision with obstacles
        float diff_x;
        diff_x = Mathf.Abs(Mathf.Abs(obstacle_pos_x) - Mathf.Abs(x));
        if (diff_x > threshold_dist)
        {
            Instantiate(potionPrefab.transform.gameObject, potionPosition, Quaternion.identity, transform);
            return;
        }

        float diff_y;
        diff_y = Mathf.Abs(Mathf.Abs(obstacle_pos_y) - Mathf.Abs(y));
        if (diff_y > threshold_dist)
        {
            Instantiate(potionPrefab.transform.gameObject, potionPosition, Quaternion.identity, transform);
            return;
        }

        float diff_z;
        diff_z = Mathf.Abs(Mathf.Abs(obstacle_pos_z) - Mathf.Abs(z));
        if (diff_z > threshold_dist)
        {
            Instantiate(potionPrefab.transform.gameObject, potionPosition, Quaternion.identity, transform);
            return;
        }
    }
    void SpawnGoldenEggs()
    {
        float z;
        float x;
        float y;
        // Choose a random point to spawn fruit
        int goldenEggOffset = Random.Range(-16, 16);
        int goldenEggOffsetY = Random.Range(0, 5);
        Transform goldenEggPoint = transform.GetChild(9).transform;
        z = goldenEggPoint.position.z;
        z = z + goldenEggOffset;
        x = goldenEggPoint.position.x;
        x = x - goldenEggOffset;
        y = goldenEggPoint.position.y;
        y = y + goldenEggOffsetY;

        Vector3 goldenEggPosition = new Vector3(x, y, z);

        // Avoid Collision with obstacles
        float diff_x;
        diff_x = Mathf.Abs(Mathf.Abs(obstacle_pos_x) - Mathf.Abs(x));
        if (diff_x > threshold_dist)
        {
            Instantiate(goldenEggPrefab.transform.gameObject, goldenEggPosition, Quaternion.identity, transform);
            return;
        }

        float diff_y;
        diff_y = Mathf.Abs(Mathf.Abs(obstacle_pos_y) - Mathf.Abs(y));
        if (diff_y > threshold_dist)
        {
            Instantiate(goldenEggPrefab.transform.gameObject, goldenEggPosition, Quaternion.identity, transform);
            return;
        }

        float diff_z;
        diff_z = Mathf.Abs(Mathf.Abs(obstacle_pos_z) - Mathf.Abs(z));
        if (diff_z > threshold_dist)
        {
            Instantiate(goldenEggPrefab.transform.gameObject, goldenEggPosition, Quaternion.identity, transform);
            return;
        }

        
    }
    void SpawnObstacle ()
    {

        //Choose if spawn a moving obstacle-less chance
         int moving = Random.Range(0, 5);
        //int moving = 1;
        if (moving < 1) {
            Instantiate(obstaclesPrefab.transform.GetChild(5).gameObject, transform.GetChild(3).transform.position, Quaternion.identity, transform);
            obstacle_pos_x = transform.GetChild(3).transform.position.x;
            obstacle_pos_y = 1.0f;
            obstacle_pos_z = transform.GetChild(3).transform.position.z;

        }
        //if (moving == 1)
        //{
        //    float x = transform.GetChild(3).transform.position.x;
        //    float y = transform.GetChild(3).transform.position.y;
        //    float z = transform.GetChild(3).transform.position.z;
           
        //    Instantiate(obstaclesPrefab.transform.GetChild(6).gameObject, new Vector3(x,y,z), Quaternion.identity, transform); 
            //obstaclesPrefab.transform.GetChild(6).gameObject.GetComponent<MovingObstacle>().dir = transform.GetChild(3).transform.right;
        //    obstacle_pos_x = x;
        //    obstacle_pos_y = 1.0f;
        //    obstacle_pos_z = z;
        //}
        else
        {

            // Choose obstacle type
            int obstacleType = Random.Range(0, 5);

            // Choose a randompoint to spawn the obstacle
            int obstacleOffset = Random.Range(-16, 16);
            Transform spawnPoint = transform.GetChild(3).transform;
            float z = spawnPoint.position.z;
            z = z + obstacleOffset;
            float x = spawnPoint.position.x;
            x = x - obstacleOffset;
            Vector3 obstaclePosition = new Vector3(x, spawnPoint.position.y, z);

            //Choose randomly a rotation for the obstacle
            Quaternion rotation;// = Quaternion.LookRotation(spawnPoint.forward);
            if (obstacleType == 2)//Wheel Barrow orientation
            {
                int frequency = Random.Range(0, 3);
                if (frequency == 0)
                    rotation = Quaternion.LookRotation(spawnPoint.forward);
                else if (frequency == 1)
                    rotation = Quaternion.LookRotation(-spawnPoint.right);
                else
                    rotation = Quaternion.LookRotation(-spawnPoint.forward);
            }
            else
            {
                int frequency = Random.Range(0, 2);
                if (frequency == 0)
                    rotation = Quaternion.LookRotation(spawnPoint.forward);
                else
                    rotation = Quaternion.LookRotation(-spawnPoint.right);
            }


            // spawnPoint.position.x = spawnPoint.position.x + 0.1f;
            // Spawn the obstacle at the position
            Instantiate(obstaclesPrefab.transform.GetChild(obstacleType).gameObject, obstaclePosition, rotation, transform);
            obstacle_pos_x = x;
            obstacle_pos_y = 1f;
            obstacle_pos_z = z;
        }
    }
    
}
