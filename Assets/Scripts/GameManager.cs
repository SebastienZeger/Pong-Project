using TMPro;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    private int player1Score;
    private int player2Score;

    public TMP_Text player1Text;
    public TMP_Text player2Text;
    public Ball ball;
    public GameObject gameMenuUI;


    public void player1Scored()
    {
        player1Score++;
        player1Text.text = player1Score.ToString();
        Debug.Log(player1Score);
        ball.resetBallPos();
        StartCoroutine(ball.RespawnBall(1));
        if (player1Score  == 10)
        {
            gameMenuUI.SetActive(true);
            PauseGame();
        }

    }
    
    public void player2Scored()
    {
        player2Score++;
        player2Text.text = player2Score.ToString();
        Debug.Log(player2Score);
        ball.resetBallPos();
        StartCoroutine(ball.RespawnBall(-1));
        if (player2Score == 10)
        {
            gameMenuUI.SetActive(true);
            PauseGame();
        }

    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }
}
