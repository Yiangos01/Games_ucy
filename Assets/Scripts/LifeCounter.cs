using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCounter : MonoBehaviour
{
    ChickenStatus chs;
    public int heart;
    // Start is called before the first frame update
    void Start()
    {
        chs = GameObject.FindGameObjectWithTag("Player").GetComponent<ChickenStatus>();
        heart = chs.heart;
    }

    // Update is called once per frame
    void Update()
    {
        heart = chs.heart;
    }
}
