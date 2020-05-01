using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    private GameObject Player;
    public float speed = 3.5f;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
        if(Vector3.Distance(Player.transform.position, transform.position)<4)
        {
            speed = 3.75f;
        }
        else
        {
            speed = 3.5f;
        }
    }
}
