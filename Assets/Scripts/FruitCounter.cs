using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCounter : MonoBehaviour
{
    ChickenStatus chs;
    public int food;
    // Start is called before the first frame update
    void Start()
    {
         chs = GameObject.FindGameObjectWithTag("Player").GetComponent<ChickenStatus>();
         food = chs.food;
    }

    // Update is called once per frame
    void Update()
    {
        food = chs.food;
    }
}
