using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Data : MonoBehaviour
{
    public static int p1Wp = 0;
    public static int p2Wp = 0;
    public static int turn = 1;

    public static float p1health = 100f;
    public static float p2health = 100f;
    public static bool minigameWin = true;

    public static int winner;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Win")
        {
            p1health = 100f;
            p2health = 100f;

            turn = 1;
            p1Wp = - GameControl.diceSideThrown;
            p2Wp = - GameControl.diceSideThrown;

            GameControl.gameOver = false;
        }
        else
        {
            turn = Dice.whosTurn;
            p1Wp = GameControl.p1Startwp - GameControl.diceSideThrown;
            p2Wp = GameControl.p2Startwp - GameControl.diceSideThrown;
        }
    }
}
