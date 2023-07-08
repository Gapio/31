using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] SoccerGameManager soccerGameManager;
    //[SerializeField] float minimum;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BlueGoal") soccerGameManager.scoreGoal(true);
        else if (collision.gameObject.tag == "RedGoal") soccerGameManager.scoreGoal(false);
    }
}
