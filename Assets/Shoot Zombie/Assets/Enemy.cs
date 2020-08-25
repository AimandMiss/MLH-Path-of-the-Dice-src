using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public GameObject Character;
    public Transform player;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    private Vector2 movement;


    void Update()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
         Character = GameObject.FindGameObjectWithTag("Player");
         player = Character.transform;
                Vector3 direction = player.position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
                rb.rotation = angle;
                direction.Normalize();
                movement = direction;             
    }
    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction)
    {
            rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
    public void TakeDamage (int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    
}
