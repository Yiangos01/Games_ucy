using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundLeft : MonoBehaviour
{
    GroundSpawner groundSpawner;
    public GameObject obstaclesPrefab;
    public GameObject treesPrefab;
    public GameObject fruitsPrefab;
    public GameObject goldenEggPrefab;
    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        //SpawnObstacle();
        SpawnTrees();
        SpawnFruits();
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")//If player exits
            groundSpawner.SpawnTile();
        if (other.gameObject.tag == "CameraCollider")//If camera exits
        {
            Destroy(gameObject, 4);
        }

    }
    // Update is called once per frame
    void Update()
    {

    }

    

    void SpawnTrees()
    {
        // Choose random decor to fill decor positions
        // 1
        Transform DecorPoint = transform.GetChild(8).transform;
        int decorType = Random.Range(0, 9);
        Instantiate(treesPrefab.transform.GetChild(decorType).gameObject, DecorPoint.position, Quaternion.identity, transform);
        // 2
        DecorPoint = transform.GetChild(9).transform;
        decorType = Random.Range(0, 9);
        Instantiate(treesPrefab.transform.GetChild(decorType).gameObject, DecorPoint.position, Quaternion.identity, transform);
        // 3
        DecorPoint = transform.GetChild(10).transform;
        decorType = Random.Range(0, 9);
        Instantiate(treesPrefab.transform.GetChild(decorType).gameObject, DecorPoint.position, Quaternion.identity, transform);
        // 4
        DecorPoint = transform.GetChild(11).transform;
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
        int fruitOffset = Random.Range(-10, 10);
        int fruitOffsetY = Random.Range(0, 5);
        Transform fruitPoint = transform.GetChild(12).transform;
        z = fruitPoint.position.z;
        z = z + fruitOffset;
        x = fruitPoint.position.x;
        x = x - fruitOffset;
        y = fruitPoint.position.y;
        y = y + fruitOffsetY;
        Vector3 fruitPosition = new Vector3(x, y, z);
        Instantiate(fruitsPrefab.transform.GetChild(fruitType).gameObject, fruitPosition, Quaternion.identity, transform);
    }
    void SpawnGoldenEggs()
    {
        float z;
        float x;
        float y;
        // Choose a random point to spawn fruit
        int goldenEggOffset = Random.Range(-10, 10);
        int goldenEggOffsetY = Random.Range(0, 5);
        Transform goldenEggPoint = transform.GetChild(13).transform;
        z = goldenEggPoint.position.z;
        z = z + goldenEggOffset;
        x = goldenEggPoint.position.x;
        x = x - goldenEggOffset;
        y = goldenEggPoint.position.y;
        y = y + goldenEggOffsetY;

        Vector3 goldenEggPosition = new Vector3(x, y, z);
        Instantiate(goldenEggPrefab.transform.gameObject, goldenEggPosition, Quaternion.identity, transform);
    }
    void SpawnObstacle()
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
    }
}
