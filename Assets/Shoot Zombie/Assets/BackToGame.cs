using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer.currentTime <= 0)
        {
            Data.minigameWin = true;
            SceneManager.LoadScene("MainGame");
        }
        else if (PlayerHealth.currenthealth <= 0)
        {
            Data.minigameWin = false;
            SceneManager.LoadScene("MainGame");
        }
    }
}
