using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplayUI : MonoBehaviour
{
    public Text score;
    
    GameObject fruitGO;
    public int initialScore = 100;
    int sum;
    int numFruits;
    // Start is called before the first frame update
    void Start()
    {
        
        fruitGO = GameObject.FindGameObjectWithTag("FruitCounter");
        numFruits = fruitGO.GetComponent<FruitCounter>().food;
        score.text = initialScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        numFruits = fruitGO.GetComponent<FruitCounter>().food;
        sum = initialScore + numFruits;
        score.text = sum.ToString();
    }
}
