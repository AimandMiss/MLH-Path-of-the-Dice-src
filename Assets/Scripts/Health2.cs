using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health2 : MonoBehaviour
{
    Image bar;
    public float maxHealth = 100f;
    public float health;

    void Start()
    {
        bar = GetComponent<Image>();
        health = Data.p2health;
    }

    void Update()
    {
        health = Data.p2health;
        bar.fillAmount = health / maxHealth;
    }
}
