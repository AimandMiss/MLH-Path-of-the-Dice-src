using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public Transform[] waypoints;
    public int index = 0;
    public float moveSpeed = 1f;
    public bool moveAllowed = false;

    public int[] events = new int[5];
    int x;
    public Animator anim;

    void Start()
    {
        transform.position = waypoints[index].transform.position;


        for (int i = 0; i < events.Length; i++)
        {
            x = Random.Range(2, waypoints.Length);

            if (!events.Contains(x))
                events[i] = x;
            else
                events[i] = Random.Range(2, waypoints.Length);
        }
    }

    void Update()
    {
        if (moveAllowed)
        {
            anim.SetBool("Walk", true);
            Move();
        }
    }

    private void Move()
    {
        if (index < waypoints.Length)
        {
                transform.position = Vector2.MoveTowards(transform.position, waypoints[index].transform.position, moveSpeed * Time.deltaTime);

                if (transform.position == waypoints[index].transform.position)
                {
                    index++;
                }
        }
    }
}
