using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Linq;

public class GameControl : MonoBehaviour
{
    private static GameObject p1, p2;
    public GameObject dice;

    public GameObject[] img;
    public TextMeshProUGUI text;
    public Color winColor, regColor, eventColor;

    public static int diceSideThrown = 0;
    public static int p1Startwp= 0;
    public static int p2Startwp = 0;

    public Animator changer, p1Anim, p2Anim;
    public bool p1Dead, p2Dead;

    public static bool gameOver = false;


    void Start()
    {
        p1 = GameObject.Find("P1");
        p2 = GameObject.Find("P2");

        p1.GetComponent<FollowPath>().moveAllowed = true;
        p2.GetComponent<FollowPath>().moveAllowed = true;

        p1Startwp = Data.p1Wp;
        p2Startwp = Data.p2Wp;

        p1.GetComponent<FollowPath>().moveAllowed = true;
        p2.GetComponent<FollowPath>().moveAllowed = true;

        p1Dead = p2Dead = false;
    }

    void Update()
    {
        if (p1.GetComponent<FollowPath>().index > p1Startwp + diceSideThrown)
        {
            p1.GetComponent<FollowPath>().moveAllowed = false;
            p1Anim.SetBool("Walk", false);

            if (p1.GetComponent<FollowPath>().events.Contains(p1.GetComponent<FollowPath>().index))
            {
                dice.SetActive(false);
                StartCoroutine("Event", 1);
                if (!Data.minigameWin)
                {
                    TakeDamage(1);
                }
            }

            if (!Data.minigameWin)
            {
                TakeDamage(1);
                Data.minigameWin = true;
            }

            img[0].SetActive(false);
            img[1].SetActive(true);

            p1Startwp = p1.GetComponent<FollowPath>().index - 1;
        }

        if (p2.GetComponent<FollowPath>().index > p2Startwp + diceSideThrown)
        {
            p2.GetComponent<FollowPath>().moveAllowed = false;
            p2Anim.SetBool("Walk", false);


            if (p2.GetComponent<FollowPath>().events.Contains(p2.GetComponent<FollowPath>().index))
            {
                dice.SetActive(false);
                StartCoroutine("Event", 2);
                if (!Data.minigameWin)
                {
                    TakeDamage(2);
                }
            }

            if (!Data.minigameWin)
            {
                TakeDamage(2);
                Data.minigameWin = true;
            }

            img[1].SetActive(false);
            img[0].SetActive(true);

            p2Startwp = p2.GetComponent<FollowPath>().index - 1;
        }

        if (Data.p1health <= 0 || p1Dead)
        {
            p1Dead = true;
            p1Anim.SetBool("Dead", true);
            StartCoroutine("Winner", 2);
        }

        if (Data.p2health <= 0 || p2Dead)
        {
            p2Dead = true;
            p2Anim.SetBool("Dead", true);
            StartCoroutine("Winner", 1);
        }

        if (p1.GetComponent<FollowPath>().index == p1.GetComponent<FollowPath>().waypoints.Length)
        {
            Data.winner = 1;
            StartCoroutine("Winner", 1);
        }

        if (p2.GetComponent<FollowPath>().index == p2.GetComponent<FollowPath>().waypoints.Length)
        {
            Data.winner = 2;
            StartCoroutine("Winner", 2);
        }
    }

    public static void MovePlayer(int playerToMove)
    {
        switch (playerToMove)
        {
            case 1:
                p1.GetComponent<FollowPath>().moveAllowed = true;
                break;
            
            case 2:
                p2.GetComponent<FollowPath>().moveAllowed = true;
                break;

            default:
                break;
        }
    }

    private IEnumerator Event(int player)
    {
        
        //yield return new WaitForSeconds(.1f);
        text.color = eventColor;
        text.text = "Surprise event for Player " + player;

        yield return new WaitForSeconds(1f);
        changer.SetTrigger("change");

        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("Shoot zombie");
    }

    private IEnumerator Winner(int player)
    {
        //yield return new WaitForSeconds(.1f);
        switch (player)
        {
            case 1:
                Data.winner = 1;
                gameOver = true;
                break;

            case 2:
                Data.winner = 2;
                gameOver = true;
                break;
        }

        yield return new WaitForSeconds(.2f);
        changer.SetTrigger("change");

        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("Win");
    }

    void TakeDamage(int player)
    {
        if (player == 1)
        {
            Data.p1health -= 25f;
        }
        else if(player == 2)
        {
            Data.p2health -= 25f;
        }
    }
}
