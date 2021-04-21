﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    public GameObject obstaclesPrefab;
    public GameObject treesPrefab;
    public GameObject fruitsPrefab;
    public GameObject goldenEggPrefab;
    public GameObject goldenEggCratePrefab;
    public GameObject potionPrefab;
    GameObject player;
    ParticleSystem fog;
    public List<float> obstacle_pos_x;
    public List<float> obstacle_pos_y;
    public List<float> obstacle_pos_z;
    public float threshold_dist;
    bool barn;//If spawn barn is true
    public bool hardMode;

    // Start is called before the first frame update
    void Start()
    {   
        Debug.Log("Start first line");
        //Always spawn decor
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        player = GameObject.FindGameObjectWithTag("Player");
        fog = transform.GetChild(11).GetComponent<ParticleSystem>();
        barn = groundSpawner.isBarn;
        SpawnTrees();

        if (!barn) {//If not spawn barn
            if (!groundSpawner.isStart)
            {//At the start of the game don't spawn obstacles
             //Choose if spawn a moving obstacle-less chance
                int moving = Random.Range(0, 5);
                if (hardMode)
                {
                    // Avoid creating moving and stationary obstacle
                    if (moving < 1)
                    {
                        SpawnObstacle(true);
                    }
                    else
                    {
                        SpawnObstacle(false);
                        SpawnObstacle(false);
                    }
                }
                else
                {
                    SpawnObstacle(moving < 1);
                }
            }

            if (groundSpawner.isStart)
            {
                transform.GetChild(11).gameObject.SetActive(false);
            }
            // Spawn only one type of object on a single tile

            //Spawn eggs less frequent-0.33 chance

            int frequencyEgg = Random.Range(0, 3);
            int frequencyPotion = Random.Range(0, 20);
            int frequencyCrateEgg = Random.Range(0, 3);
            if (frequencyEgg < 1)
            {
                SpawnGoldenEggs(frequencyCrateEgg<1);
            }
            if (frequencyPotion < 1)
            {
                SpawnPotion();
            }
            
            SpawnFruits();
           
        }
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
    void SpawnFruits()
    {
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
        bool deploy = true;
        foreach (float ob_x in obstacle_pos_x)
        {
            
            Debug.Log("in for loop");
            float diff_x;
            diff_x = Mathf.Abs(Mathf.Abs(ob_x) - Mathf.Abs(x));
            if (diff_x <= threshold_dist)
            {
                deploy = false;
                break;
            }
        }
        if (deploy)
        {
            Instantiate(fruitsPrefab.transform.GetChild(fruitType).gameObject, fruitPosition, Quaternion.identity, transform);
            obstacle_pos_x.Add(x);
            obstacle_pos_y.Add(y);
            obstacle_pos_z.Add(z);
            return;
        }

        deploy = true;
        foreach (float ob_y in obstacle_pos_y)
        {
            float diff_y;
            diff_y = Mathf.Abs(Mathf.Abs(ob_y) - Mathf.Abs(y));
            if (diff_y <= threshold_dist)
            {
                deploy = false;
                break;
            }
        }
        if (deploy)
        {
            Instantiate(fruitsPrefab.transform.GetChild(fruitType).gameObject, fruitPosition, Quaternion.identity, transform);
            obstacle_pos_x.Add(x);
            obstacle_pos_y.Add(y);
            obstacle_pos_z.Add(z);
            return;
        }

        deploy = true;
        foreach (float ob_z in obstacle_pos_z)
        {
           float diff_z;
           diff_z = Mathf.Abs(Mathf.Abs(ob_z) - Mathf.Abs(z));
           if (diff_z <= threshold_dist)
            {
                deploy = false;
                break;
            }
        }
        if (deploy)
        {
            Instantiate(fruitsPrefab.transform.GetChild(fruitType).gameObject, fruitPosition, Quaternion.identity, transform);
            obstacle_pos_x.Add(x);
            obstacle_pos_y.Add(y);
            obstacle_pos_z.Add(z);
            return;
        }

    }

    void SpawnPotion()
    {
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
        bool deploy = true;
        foreach (float ob_x in obstacle_pos_x)
        {

            Debug.Log("in for loop");
            float diff_x;
            diff_x = Mathf.Abs(Mathf.Abs(ob_x) - Mathf.Abs(x));
            if (diff_x <= threshold_dist)
            {
                deploy = false;
                break;
            }
        }
        if (deploy)
        {
            Instantiate(potionPrefab.transform.gameObject, potionPosition, Quaternion.identity, transform);
            obstacle_pos_x.Add(x);
            obstacle_pos_y.Add(y);
            obstacle_pos_z.Add(z);
            return;
        }

        deploy = true;
        foreach (float ob_y in obstacle_pos_y)
        {
            float diff_y;
            diff_y = Mathf.Abs(Mathf.Abs(ob_y) - Mathf.Abs(y));
            if (diff_y <= threshold_dist)
            {
                deploy = false;
                break;
            }
        }
        if (deploy)
        {
            Instantiate(potionPrefab.transform.gameObject, potionPosition, Quaternion.identity, transform);
            obstacle_pos_x.Add(x);
            obstacle_pos_y.Add(y);
            obstacle_pos_z.Add(z);
            return;
        }

        deploy = true;
        foreach (float ob_z in obstacle_pos_z)
        {
            float diff_z;
            diff_z = Mathf.Abs(Mathf.Abs(ob_z) - Mathf.Abs(z));
            if (diff_z <= threshold_dist)
            {
                deploy = false;
                break;
            }
        }
        if (deploy)
        {
            Instantiate(potionPrefab.transform.gameObject, potionPosition, Quaternion.identity, transform);
            obstacle_pos_x.Add(x);
            obstacle_pos_y.Add(y);
            obstacle_pos_z.Add(z);
            return;
        }



        
    }

    void SpawnGoldenEggs(bool isCrate)
    {
        GameObject eggType;
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
        //Create egg with crate
        if (isCrate)
        {
            eggType = goldenEggCratePrefab;
        }
        else
        {
            eggType = goldenEggPrefab;
        }
        // Avoid Collision with other objects
        bool deploy = true;
        foreach (float ob_x in obstacle_pos_x)
        {

            Debug.Log("in for loop");
            float diff_x;
            diff_x = Mathf.Abs(Mathf.Abs(ob_x) - Mathf.Abs(x));
            if (diff_x <= threshold_dist)
            {
                deploy = false;
                break;
            }
        }
        if (deploy)
        {
            Instantiate(eggType.transform.gameObject, goldenEggPosition, Quaternion.identity, transform);
            obstacle_pos_x.Add(x);
            obstacle_pos_y.Add(y);
            obstacle_pos_z.Add(z);
            return;
        }

        deploy = true;
        foreach (float ob_y in obstacle_pos_y)
        {
            float diff_y;
            diff_y = Mathf.Abs(Mathf.Abs(ob_y) - Mathf.Abs(y));
            if (diff_y <= threshold_dist)
            {
                deploy = false;
                break;
            }
        }
        if (deploy)
        {
            Instantiate(eggType.transform.gameObject, goldenEggPosition, Quaternion.identity, transform);
            obstacle_pos_x.Add(x);
            obstacle_pos_y.Add(y);
            obstacle_pos_z.Add(z);
            return;
        }

        deploy = true;
        foreach (float ob_z in obstacle_pos_z)
        {
            float diff_z;
            diff_z = Mathf.Abs(Mathf.Abs(ob_z) - Mathf.Abs(z));
            if (diff_z <= threshold_dist)
            {
                deploy = false;
                break;
            }
        }
        if (deploy)
        {
            Instantiate(eggType.transform.gameObject, goldenEggPosition, Quaternion.identity, transform);
            obstacle_pos_x.Add(x);
            obstacle_pos_y.Add(y);
            obstacle_pos_z.Add(z);
            return;
        }

    }

    void SpawnObstacle (bool moving)
    {

       
       
        if (moving)
        
        { //Choose type of moving obstacle
            int chooseMovingType = Random.Range(0, 2);
            if (chooseMovingType < 1)//Rotating obstacle
            {
                Instantiate(obstaclesPrefab.transform.GetChild(5).gameObject, transform.GetChild(3).transform.position, Quaternion.identity, transform);
                float x = transform.GetChild(3).transform.position.x;
                float z = transform.GetChild(3).transform.position.z;
                obstacle_pos_x.Add(x);
                obstacle_pos_y.Add(1.5f);
                obstacle_pos_z.Add(z);

            }
            else//Moving Back and forth obstacle
            {
                Transform spawnPoint = transform.GetChild(3).transform;
                float x = spawnPoint.position.x;//transform.GetChild(3).transform.position.x;
                float y = spawnPoint.position.y;
                float z = spawnPoint.position.z; //transform.GetChild(3).transform.position.z;
                obstaclesPrefab.transform.GetChild(6).gameObject.GetComponent<MovingObstacle>().direction = -spawnPoint.right;
                Instantiate(obstaclesPrefab.transform.GetChild(6).gameObject, spawnPoint.position, Quaternion.LookRotation(spawnPoint.forward), transform);

                obstacle_pos_x.Add(x);
                obstacle_pos_y.Add(2f);
                obstacle_pos_z.Add(z);
            }
        }
        else//Stationary obstacle
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

            bool deploy = true;
            foreach (float ob_x in obstacle_pos_x)
            {

                Debug.Log("in for loop");
                float diff_x;
                diff_x = Mathf.Abs(Mathf.Abs(ob_x) - Mathf.Abs(x));
                if (diff_x <= threshold_dist)
                {
                    deploy = false;
                    break;
                }
            }
            if (deploy)
            {
                Instantiate(obstaclesPrefab.transform.GetChild(obstacleType).gameObject, obstaclePosition, rotation, transform);
                obstacle_pos_x.Add(x);
                obstacle_pos_y.Add(1f);
                obstacle_pos_z.Add(z);
                return;
            }

            deploy = true;
            foreach (float ob_y in obstacle_pos_y)
            {
                float diff_y;
                diff_y = Mathf.Abs(Mathf.Abs(ob_y) - Mathf.Abs(1f));
                if (diff_y <= threshold_dist)
                {
                    deploy = false;
                    break;
                }
            }
            if (deploy)
            {
                Instantiate(obstaclesPrefab.transform.GetChild(obstacleType).gameObject, obstaclePosition, rotation, transform);
                obstacle_pos_x.Add(x);
                obstacle_pos_y.Add(1f);
                obstacle_pos_z.Add(z);
                return;
            }

            deploy = true;
            foreach (float ob_z in obstacle_pos_z)
            {
                float diff_z;
                diff_z = Mathf.Abs(Mathf.Abs(ob_z) - Mathf.Abs(z));
                if (diff_z <= threshold_dist)
                {
                    deploy = false;
                    break;
                }
            }
            if (deploy)
            {
                Instantiate(obstaclesPrefab.transform.GetChild(obstacleType).gameObject, obstaclePosition, rotation, transform);
                obstacle_pos_x.Add(x);
                obstacle_pos_y.Add(1f);
                obstacle_pos_z.Add(z);
                return;
            }

            // spawnPoint.position.x = spawnPoint.position.x + 0.1f;
            // Spawn the obstacle at the position
            //Instantiate(obstaclesPrefab.transform.GetChild(obstacleType).gameObject, obstaclePosition, rotation, transform);
        }
    }
    void Update() {
        Vector3 dist = transform.position - player.transform.position;
        if(fog!=null)
            if (dist.magnitude <= 280f && fog.isPlaying)
                fog.Stop();
    }
    
}
