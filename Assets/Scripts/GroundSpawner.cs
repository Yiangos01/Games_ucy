using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTile;
    public GameObject leftTile;
    public GameObject rightTile;
    public GameObject barn;
    public GameObject lake;
    public bool isStart = false;
    Vector3 nextSpawnPoint;
    Vector3 global_rotation;

    public void SpawnTile()
    {
        int tile = Random.Range(0, 20);

        if (tile < 16)
        {
            SpawnStraightTile();
        }
        else if (tile < 18)
        {
            SpawnRightTile();
            //SpawnStraightTile();
        }
        else if (tile <= 20)
        {
            SpawnLeftTile();
            //SpawnStraightTile();
        }

    }

    public void SpawnStraightTile()
    {

        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        temp.transform.Rotate(global_rotation.x, global_rotation.y, global_rotation.z, Space.Self);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
       
        
    }

    public void SpawnLeftTile()
    {
       
        GameObject temp = Instantiate(leftTile, nextSpawnPoint, Quaternion.identity);
        temp.transform.Rotate(global_rotation.x, global_rotation.y, global_rotation.z, Space.Self);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
        
        float rot = (global_rotation.y - 90) % 360.0f;
        if (rot < 0)
        {
            rot = 360 + rot;
        }
        global_rotation = new Vector3(0, rot, 0);
        
    }

    public void SpawnRightTile()
    {
        
        GameObject temp = Instantiate(rightTile, nextSpawnPoint , Quaternion.identity);
        temp.transform.Rotate(global_rotation.x, global_rotation.y, global_rotation.z, Space.Self);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
       
        float rot = (global_rotation.y + 90) % 360.0f;
        global_rotation = new Vector3(0, rot, 0);
      

    }
    public void SpawnBarn() {
        GameObject temp = Instantiate(barn, nextSpawnPoint, Quaternion.LookRotation(-Vector3.forward));
        temp.transform.Rotate(global_rotation.x, global_rotation.y, global_rotation.z, Space.Self);

    }
    //Spawn Chickens when reached the barn
    //public void SpawnChickens() 
    //{ 
    //}

    public void SpawnLake() {
        GameObject temp = Instantiate(lake, new Vector3(nextSpawnPoint.x, -0.2f, nextSpawnPoint.z), Quaternion.identity);
        temp.transform.Rotate(global_rotation.x, global_rotation.y, global_rotation.z, Space.Self);
    }
        // Start is called before the first frame update
    void Start()
    {
        
        global_rotation = new Vector3(0, 0, 0);
        for (int i =0; i < 4; i++)
        {  
            isStart = true;
            SpawnStraightTile();

            }

    }

    // Update is called once per frame
    void Update()
    {
        isStart = false;
    }


}
