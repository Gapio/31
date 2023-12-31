using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

[System.Serializable]
public class PlayerAndPos
{
    public GameObject playerGamObject;
    public Vector3 position;
    public Quaternion rotation;
}

public class SoccerGameManager : MonoBehaviour
{
    public static int redScore;
    public static int blueScore;
    public TMP_Text redScoreText;
    public TMP_Text blueScoreText;

    [SerializeField] GameObject playerParent;
    [SerializeField] GameObject circle;
    [SerializeField] GameObject triangle;
    [SerializeField] GameObject goalkeeper;
    [SerializeField] GameObject ball;
    [SerializeField] GameObject RedTeam;

    [SerializeField] GameObject blueTeamScorePopUp;
    [SerializeField] GameObject redTeamScorePopUp;

    //private void Start()
    //{
    //    trianglepos = triangle.transform.position;
    //    circlepos = circle.transform.position;
    //    linepos = line.transform.position;

    //    for (int i = 0; i < blueTeam.Length; i++)
    //    {
    //        blueTeam[i].position = blueTeam[i].playerGamObject.transform.position;
    //        blueTeam[i].rotation = blueTeam[i].playerGamObject.transform.rotation;
    //        //blueTeam[i].playerGamObject.GetComponent<Rigidbody>().vel = Vector3.zero;

    //        //redTeam[i].playerGamObject.transform.position = redTeam[i].playerPosition.position;
    //        //redTeam[i].playerGamObject.transform.rotation = redTeam[i].playerPosition.rotation;
    //    }
    //}

    public void scoreGoal(bool blueGoal) => StartCoroutine(startScoreGoal(blueGoal));

    IEnumerator startScoreGoal(bool blueGoal)
    {
        if (blueGoal)
        {
            redScore++;
            redScoreText.text = redScore.ToString();

            redTeamScorePopUp.SetActive(true);
        }
        else
        {
            blueScore++;
            blueScoreText.text = blueScore.ToString();

            blueTeamScorePopUp.SetActive(true);
        }

        RedTeam.SetActive(false);
        ball.transform.position = new Vector3(0, 1, 4);
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.SetActive(false);

        for (int i = 0; i < playerParent.transform.childCount; i++)
        {
            Destroy(playerParent.transform.GetChild(i).gameObject);
        }

        yield return new WaitForSeconds(2);

        blueTeamScorePopUp.SetActive(false);
        redTeamScorePopUp.SetActive(false);

        RedTeam.SetActive(true);
        ball.SetActive(true);

        Instantiate(circle, playerParent.transform);
        Instantiate(triangle, playerParent.transform);
        Instantiate(goalkeeper, playerParent.transform);
    }
}
