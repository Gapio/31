using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : Player
{
    //ZigZag
    [SerializeField] float frequency = 10.0f; // Speed of sine movement

    public override void Move()
    {
        //transform.position += Vector3.left * Time.deltaTime * speed;
        transform.position += Vector3.forward * Mathf.Cos(Time.time * frequency) * force * Time.deltaTime;
    }
}
