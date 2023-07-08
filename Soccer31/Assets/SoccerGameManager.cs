using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

[System.Serializable]
public class PlayerAndPos
{
    public GameObject playerGamObject;
    [HideInInspector] public Transform playerPosition;
}

public class SoccerGameManager : MonoBehaviour
{
    public static int redScore;
    public static int blueScore;
    public TMP_Text redScoreText;
    public TMP_Text blueScoreText;


    [SerializeField] PlayerAndPos[] blueTeam;
    [SerializeField] Vector3[] blueTeamStartPositions;
    [SerializeField] Quaternion[] blueTeamStartRotations;
    [SerializeField] PlayerAndPos[] redTeam;
    [SerializeField] GameObject ball;

    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            blueTeam[i].playerPosition.position = blueTeamStartPositions[i];
            blueTeam[i].playerPosition.rotation = blueTeamStartRotations[i];

            //redTeam[i].playerGamObject.transform.position = redTeam[i].playerPosition.position;
            //redTeam[i].playerGamObject.transform.rotation = redTeam[i].playerPosition.rotation;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void scoreGoal(bool blueGoal)
    {
        if (blueGoal)
        {
            redScore++;
            redScoreText.text = redScore.ToString();
        }
        else
        {
            blueScore++;
            blueScoreText.text = blueScore.ToString();
        }

        ball.transform.position = new Vector3(0, 1, 4);
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;

        for (int i = 0; i < blueTeam.Length; i++)
        {
            blueTeam[i].playerGamObject.transform.position = blueTeamStartPositions[i];
            blueTeam[i].playerGamObject.transform.rotation = blueTeamStartRotations[i];
            blueTeam[i].playerGamObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

            //redTeam[i].playerGamObject.transform.position = redTeam[i].playerPosition.position;
            //redTeam[i].playerGamObject.transform.rotation = redTeam[i].playerPosition.rotation;
        }
    }
}
