using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenEgg : MonoBehaviour
{
    ChickenStatus chs;
    public int goldenEgg;
    // Start is called before the first frame update
    void Start()
    {
        chs = GameObject.FindGameObjectWithTag("Player").GetComponent<ChickenStatus>();
        goldenEgg = chs.goldenEgg;
    }

    // Update is called once per frame
    void Update()
    {
        goldenEgg = chs.goldenEgg;
    }
}
