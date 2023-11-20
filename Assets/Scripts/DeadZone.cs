using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeadZone : MonoBehaviour
{

    public Text scorePlayerText;
    public Text scoreEnemyText;

    int scorePlayerQuantity;
    int scoreEnemyCuantity;

    public SceneChanger sceneChanger;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colisión");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");

        if (gameObject.tag == "Left") 
        {
            scoreEnemyCuantity++;
            updateScoreLabel(scoreEnemyText, scoreEnemyCuantity);
        } else if (gameObject.CompareTag("Right")) // if (collision.tag.Equals("Right"))
        {
            scorePlayerQuantity++;
            updateScoreLabel(scorePlayerText, scorePlayerQuantity);
        }

        collision.GetComponent<BallBehavior>().gameStarted = false;

        CheckScore();
    }

    void CheckScore()
    { 
        if(scorePlayerQuantity >= 3) 
        {
            sceneChanger.changeSceneTo("WinScene");
        } else if (scoreEnemyCuantity >= 3)
        {
            sceneChanger.changeSceneTo("LoseScene");
        }
    }

    void updateScoreLabel(Text label, int score) 
    {
        label.text = score.ToString();
    }

}
