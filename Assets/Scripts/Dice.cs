using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Dice : MonoBehaviour
{
    public Sprite[] diceSides;
    private SpriteRenderer rend;
    public static int whosTurn = 1;
    private bool coroutineAllowed = true;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rend.sprite = diceSides[5];
        whosTurn = Data.turn;
    }

    private void OnMouseDown()
    {
        if (!GameControl.gameOver && coroutineAllowed)
        {
            StartCoroutine("RollTheDice");
        }
    }

    private IEnumerator RollTheDice()
    {
        coroutineAllowed = false;
        int randomSide = 0;

        for (int i = 0; i < 20; i++)
        {
            randomSide = Random.Range(0, 5);
            rend.sprite = diceSides[randomSide];
            yield return new WaitForSeconds(0.05f);
        }

        GameControl.diceSideThrown = randomSide + 1;
        switch (whosTurn)
        {
            case 1:
                GameControl.MovePlayer(1);
                break;

            case -1:
                GameControl.MovePlayer(2);
                break;
        }

        whosTurn *= -1;
        coroutineAllowed = true;
    }
}
