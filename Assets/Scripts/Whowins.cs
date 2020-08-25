using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Whowins : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Animator anim1, anim2;

    void Update()
    {
        if (Data.winner == 1)
        {
            anim2.SetTrigger("P1Win");
        }
        else
            anim1.SetTrigger("P2Win");

        text.text = "Player " + Data.winner + " Wins!";
    }
}
