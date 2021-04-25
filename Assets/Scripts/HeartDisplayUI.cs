using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HeartDisplayUI : MonoBehaviour
{
    GameObject lifeGO;
    int numHearts;
    public Image[] hearts;
   // Color initialColor = new Color(0.6698f, 0.654f, 0.654f, 1f);
    Color initialColor = new Color(0.5f, 0.5f, 0.5f, 1f);
    // Start is called before the first frame update
    void Start()
    {
        lifeGO = GameObject.FindGameObjectWithTag("LifeCounter");
        numHearts = lifeGO.GetComponent<LifeCounter>().heart;
        for (int i = 4; i < hearts.Length; i++)//Four hearts are white, other are not
           hearts[i].color = initialColor;

    }

    // Update is called once per frame
    void Update()
    {
        numHearts = lifeGO.GetComponent<LifeCounter>().heart;
        for (int i = 0; i < numHearts; i++)
        {

           hearts[i].color = Color.white;

        }
        for (int i = numHearts; i < hearts.Length; i++)
        {

            hearts[i].color = initialColor;

        }
    }
}
