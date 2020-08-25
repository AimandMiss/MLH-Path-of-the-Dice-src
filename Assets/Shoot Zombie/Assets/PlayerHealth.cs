using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxhealth = 100;
    public static int currenthealth;
    public int damage =10;
    public Healthbar healthbar;
    public int winorlost;
    public Animator anim;

    void Start()
    {
        currenthealth = maxhealth;
        healthbar.SetMaxHealth(maxhealth);

    }

    void Update()
    {
        if (currenthealth <= 10)
        {
            winorlost = 0;
            Data.minigameWin = false;
            anim.SetTrigger("dead");
            //this.enabled = false;
//shit sucks he died lol
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            currenthealth = currenthealth - damage;
            healthbar.SetHealth(currenthealth);
        }
    }
    public int winningson()
    {
        return winorlost;
    }
}
