using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public Text gameOver;
    public void LoadMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        LoadMenu();
        // Code to execute after the delay
    }

    void Update() {
        if(gameOver.isActiveAndEnabled)
             StartCoroutine(ExecuteAfterTime(6f));
    }

}
