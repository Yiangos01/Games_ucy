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
    public GameObject spawnChickenRun;
    public GameObject spawnChickenWalk;
    Vector3 barnPos;
    Vector3 barnFor;
    public bool isStart = false;
    Vector3 nextSpawnPoint;
    Vector3 global_rotation;
    public bool isBarn = false;
    public int patienceRight = 4;
    public int patienceLeft = 4;
    int countRight;
    int countLeft;
    public int probStraightTile = 10;
    public int probTurnTile = 5;
    public ParticleSystem GroundFog;
    //public int probStraightTile;

    public void SpawnTile()
    {
        int tile = Random.Range(0, probStraightTile+probTurnTile*2);
        
        countLeft += 1;
        countRight += 1;

        if (tile < probStraightTile)
        {
            SpawnStraightTile();
        }
        else if (tile < probStraightTile+ probTurnTile)
        {
            if (countRight >= patienceRight)
            {
                SpawnRightTile();
                countRight = 0;
            }
            else
            {
                SpawnStraightTile();
            }
            //SpawnStraightTile();
        }
        else
        {
            if (countLeft >= patienceLeft)
            {
                SpawnLeftTile();
                countLeft = 0;
            }
            else
            {
                SpawnStraightTile();
            }
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
        isBarn = true;
        GameObject temp = Instantiate(barn, nextSpawnPoint, Quaternion.LookRotation(-Vector3.forward));
        temp.transform.Rotate(global_rotation.x, global_rotation.y, global_rotation.z, Space.Self);

        barnPos = temp.transform.position;
        barnFor = temp.transform.forward;

    }
    //Spawn Chickens when reached the barn
    public void SpawnChickens() 
    {
        GameObject temp = Instantiate(spawnChickenRun, new Vector3(barnPos.x, 1.0f, barnPos.z), Quaternion.identity);
        temp.transform.Rotate(global_rotation.x, global_rotation.y, global_rotation.z, Space.Self);
        GameObject temp1 = Instantiate(spawnChickenWalk, new Vector3(barnPos.x, 1.0f, barnPos.z), Quaternion.identity);
        temp1.transform.Rotate(global_rotation.x, global_rotation.y, global_rotation.z, Space.Self);
        GameObject temp2 = Instantiate(spawnChickenRun, new Vector3(barnPos.x, 1.0f, barnPos.z), Quaternion.identity);
        temp2.transform.Rotate(global_rotation.x, global_rotation.y, global_rotation.z, Space.Self);
        GameObject temp3 = Instantiate(spawnChickenWalk, new Vector3(barnPos.x, 1.0f, barnPos.z), Quaternion.identity);
        temp3.transform.Rotate(global_rotation.x, global_rotation.y, global_rotation.z, Space.Self);
        GameObject temp4 = Instantiate(spawnChickenRun, new Vector3(barnPos.x, 1.0f, barnPos.z), Quaternion.identity);
        temp4.transform.Rotate(global_rotation.x, global_rotation.y, global_rotation.z, Space.Self);
        GameObject temp5 = Instantiate(spawnChickenWalk, new Vector3(barnPos.x, 1.0f, barnPos.z), Quaternion.identity);
        temp5.transform.Rotate(global_rotation.x, global_rotation.y, global_rotation.z, Space.Self);
        GameObject temp6 = Instantiate(spawnChickenRun, new Vector3(barnPos.x, 1.0f, barnPos.z), Quaternion.identity);
        temp6.transform.Rotate(global_rotation.x, global_rotation.y, global_rotation.z, Space.Self);
        GameObject temp7 = Instantiate(spawnChickenWalk, new Vector3(barnPos.x, 1.0f, barnPos.z), Quaternion.identity);
        temp7.transform.Rotate(global_rotation.x, global_rotation.y, global_rotation.z, Space.Self);

        Destroy(temp, 10);
        Destroy(temp1, 10);
        Destroy(temp2, 10);
        Destroy(temp3, 10);
        Destroy(temp4, 10);
        Destroy(temp5, 10);
        Destroy(temp6, 10);
    }

    public void SpawnLake() {
        GameObject temp = Instantiate(lake, new Vector3(nextSpawnPoint.x, 0.8f, nextSpawnPoint.z), Quaternion.identity);
        temp.transform.Rotate(global_rotation.x, global_rotation.y, global_rotation.z, Space.Self);
    }
        // Start is called before the first frame update
    void Start()
    {
       
        global_rotation = new Vector3(0, 0, 0);
        for (int i =0; i < 20; i++)
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
