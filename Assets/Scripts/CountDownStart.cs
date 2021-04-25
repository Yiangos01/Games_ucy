using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownStart : MonoBehaviour
{
    public int countdownTime;
    public Text countdownDisplay;
    public Image backgroundFade;
    private GameObject player;
    private GameObject strengthPatternUI;
   
    private GameObject statusUI;
    private ChickenMovement playerScript;
    // Start is called before the first frame update
    void Start()
    { 
        StartCoroutine(CountdownToStart());
        //Disables only the script for the chicken, in order to not moving. Not the whole game
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript =  player.GetComponent<ChickenMovement>();
        playerScript.enabled = false;
        strengthPatternUI = GameObject.FindGameObjectWithTag("StrengthPatternUI");
      
        strengthPatternUI.GetComponent<StrengthPatternUI>().enabled = false;
     
        statusUI = GameObject.FindGameObjectWithTag("StatusUI");
        statusUI.transform.GetChild(0).gameObject.SetActive(false);
        statusUI.transform.GetChild(2).gameObject.SetActive(false);
        statusUI.transform.GetChild(3).gameObject.SetActive(false);
    }

    IEnumerator CountdownToStart() {
            
        while (countdownTime > 0) {
            countdownDisplay.text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime--;

        }

        countdownDisplay.text = "GO!";
        yield return new WaitForSeconds(1f);
        countdownDisplay.gameObject.SetActive(false);
        backgroundFade.gameObject.SetActive(false);

        playerScript.enabled = true; //Enable the script of movement again
        strengthPatternUI.GetComponent<StrengthPatternUI>().enabled = true;
     
        statusUI.transform.GetChild(0).gameObject.SetActive(true);
        statusUI.transform.GetChild(2).gameObject.SetActive(true);
        statusUI.transform.GetChild(3).gameObject.SetActive(true);
    }

   
}
