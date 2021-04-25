using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldenEggDisplayUI : MonoBehaviour
{
    GameObject eggsGO;
    int numEggs;
    public Image[] goldenEggs;
    //Color initialColor = new Color(0.6698f, 0.654f, 0.654f, 1f);
    Color initialColor = new Color(0.5f, 0.5f, 0.5f, 1f);
    // Start is called before the first frame update
    void Start()
    {
        eggsGO = GameObject.FindGameObjectWithTag("GoldenEggCounter");
        numEggs = eggsGO.GetComponent<GoldenEgg>().goldenEgg;
        for(int i =0; i<goldenEggs.Length;i++)
            goldenEggs[i].color = initialColor;
        
    }

    // Update is called once per frame
    void Update()
    {
        numEggs = eggsGO.GetComponent<GoldenEgg>().goldenEgg;

        for (int i = 0; i < numEggs; i++)
        {

            goldenEggs[i].color = Color.white;

        }
    }
}
