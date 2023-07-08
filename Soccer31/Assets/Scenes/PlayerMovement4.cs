using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement4 : Player
{
    /*public override void Move()
    {
        //angle += Time.deltaTime * angularSpeed; // update angle
        //Vector3 direction = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.up; // calculate direction from center - rotate the up vector Angle degrees clockwise
        //transform.position = center + direction * radius; // update position based on center, the direction, and the radius (which is a constant)

        //transform.position += Vector3.left * Time.deltaTime * speed;
        velocity = transform.forward * force * Time.deltaTime;
    }

    public override void LookAtVelocity()
    {
        Vector3 target = new Vector3(velocity.x, 0.0f, velocity.z);
        transform.LookAt(target + transform.position);
    }*/
}
