﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownStart : MonoBehaviour
{
    public int countdownTime;
    public Text countdownDisplay;
    public Image backgroundFade;
    private GameObject player;
    private ChickenMovement playerScript;
    // Start is called before the first frame update
    void Start()
    { 
        StartCoroutine(CountdownToStart());
        //Disables only the script for the chicken, in order to not moving. Not the whole game
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript =  player.GetComponent<ChickenMovement>();
        playerScript.enabled = false;
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

    }

   
}