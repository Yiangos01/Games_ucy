using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
   
    // Start is called before the first frame update
    void Start()
    {
     
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>(); 
        if(!groundSpawner.isStart)//At the start of the game don't spawn obstacles
            SpawnObstacle();
        //Always spawn decor and fruits
        SpawnTrees();
        SpawnFruits();
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
    void Update()
    {
        
    }

    public GameObject obstaclesPrefab;
    public GameObject treesPrefab;
    public GameObject fruitsPrefab;
    void SpawnTrees() { 
        // Choose random decor to fill decor positions
        // 1
        Transform DecorPoint = transform.GetChild(4).transform;
        int decorType = Random.Range(0, 8);
        Instantiate(treesPrefab.transform.GetChild(decorType).gameObject, DecorPoint.position, Quaternion.identity, transform);
        // 2
        DecorPoint = transform.GetChild(5).transform;
        decorType = Random.Range(0, 8);
        Instantiate(treesPrefab.transform.GetChild(decorType).gameObject, DecorPoint.position, Quaternion.identity, transform);
        // 3
        DecorPoint = transform.GetChild(6).transform;
        decorType = Random.Range(0, 8);
        Instantiate(treesPrefab.transform.GetChild(decorType).gameObject, DecorPoint.position, Quaternion.identity, transform);
        // 4
        DecorPoint = transform.GetChild(7).transform;
        decorType = Random.Range(0, 8);
        Instantiate(treesPrefab.transform.GetChild(decorType).gameObject, DecorPoint.position, Quaternion.identity, transform);
    }
    void SpawnFruits() {
        // Choose fruit type
        Transform spawnPoint = transform.GetChild(3).transform;
        float z = spawnPoint.position.z;
        float x = spawnPoint.position.x;
        int fruitType = Random.Range(0, 7);
        // Choose a random point to spawn fruit
        int fruitOffset = Random.Range(-18, 18);
        Transform fruitPoint = transform.GetChild(8).transform;
        z = fruitPoint.position.z;
        z = z + fruitOffset;
        x = fruitPoint.position.x;
        x = x - fruitOffset;
        Vector3 fruitPosition = new Vector3(x, fruitPoint.position.y, z);
        Instantiate(fruitsPrefab.transform.GetChild(fruitType).gameObject, fruitPosition, Quaternion.identity, transform);
    }
    void SpawnObstacle ()
    {
        // Choose obstacle type
        int obstacleType = Random.Range(0, 4);

        // Choose a randompoint to spawn the obstacle
        int obstacleOffset = Random.Range(-16, 16);
        Transform spawnPoint = transform.GetChild(3).transform;
        float z = spawnPoint.position.z;
        z = z + obstacleOffset;
        float x = spawnPoint.position.x;
        x = x - obstacleOffset;
        Vector3 obstaclePosition = new Vector3(x, spawnPoint.position.y, z);

        // spawnPoint.position.x = spawnPoint.position.x + 0.1f;
        // Spawn the obstacle at the position
        Instantiate(obstaclesPrefab.transform.GetChild(obstacleType).gameObject, obstaclePosition, Quaternion.identity, transform);
    }
}
