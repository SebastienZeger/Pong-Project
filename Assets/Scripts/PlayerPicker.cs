using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPicker : MonoBehaviour
{
    public GameObject player1, player2;
    public GameObject ball;
    void Start()
    {
        Debug.Log(PlayerInputManager.instance.playerCount);
        if (PlayerInputManager.instance.playerCount == 1)
        {
            Instantiate(player1, transform);
            Instantiate(player2, transform);
            StartCoroutine(SpawnBall());
        }
        else
        {
            //Instantiate(player2, transform);
            //StartCoroutine(SpawnBall());
        }
    }
    
    IEnumerator SpawnBall()
    {
        yield return new WaitForSeconds(3);
        Instantiate(ball, transform);
    }
}