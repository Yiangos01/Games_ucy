using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrengthPatternUI : MonoBehaviour
{
    ChickenStatus chSt;
   
    List<int> trgtPattern;
    
    public Image apple;
    public Image banana;
    public Image carrot;
    public Image cherry;
    public Image grape;
    public Image pumpkin;
    public Image watermelon;
    //Color initialColor = new Color(0.6698f, 0.654f, 0.654f, 1f);
    Color initialColor = new Color(0.5f, 0.5f, 0.5f, 1f);
    public List<Image> imgTargetPattern;
    Image[] temp;
    int count = 0;
    Vector3 pos;
    GameObject statusUI;
    // Start is called before the first frame update
    void Start()
    {
        chSt = GameObject.FindGameObjectWithTag("Player").GetComponent<ChickenStatus>();
        trgtPattern = chSt.targetPatternStrength;
        apple.color = initialColor;
        banana.color = initialColor;
        carrot.color = initialColor;
        cherry.color = initialColor;
        grape.color = initialColor;
        pumpkin.color = initialColor;
        watermelon.color = initialColor;

        
       temp = new Image[chSt.patternSize];
        statusUI = GameObject.FindGameObjectWithTag("StatusUI");
        pos = statusUI.transform.GetChild(1).position;
        
    }

    void StorePattern() {
        for (int i = 0; i < trgtPattern.Count; i++) {
            if (trgtPattern[i] == 1)
                imgTargetPattern.Add(apple);
            else if (trgtPattern[i] == 2)
                imgTargetPattern.Add(banana);
            else if (trgtPattern[i] == 3)
                imgTargetPattern.Add(carrot);
            else if (trgtPattern[i] == 4)
                imgTargetPattern.Add(cherry);
            else if (trgtPattern[i] == 5)
                imgTargetPattern.Add(grape);
            else if (trgtPattern[i] == 6)
                imgTargetPattern.Add(pumpkin);
            else if (trgtPattern[i] == 7)
                imgTargetPattern.Add(watermelon);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        if (trgtPattern.Count != 0 && count == 0 && !chSt.strengthMode)//Only one time at the start
        {
            StorePattern();
            count = 1;
            //Show target pattern onto screen
        for (int i = 0; i < imgTargetPattern.Count; i++) {
                // Debug.Log("UI posiiton" + pos);
                Image t = Instantiate(imgTargetPattern[i], pos, Quaternion.identity, statusUI.transform);
                pos = t.transform.GetChild(0).position;
                temp[i] = t;

        }
        }

        for (int i = 0; i < chSt.pattern.Count; i++)
        {

            temp[i].color = Color.white;

        }
        if (chSt.strengthMode && count ==1) {
            count = 0;
            for (int i = 0; i < temp.Length; i++)
                Destroy(temp[i]);
            imgTargetPattern.Clear();
            pos = statusUI.transform.GetChild(1).position;

        }

    }

}
