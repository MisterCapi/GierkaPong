using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Ball")] public GameObject ball;
    
    [Header("Score UI")] 
    public GameObject player1Text;

    public GameObject player2Text;

    private int player1Score;
    private int player2Score;
    
    public void Player1Scored()
    {
        player1Score++;
        player1Text.GetComponent<TextMeshProUGUI>().text = player1Score.ToString();
        ball.GetComponent<Ball>().Reset();
    }
    public void Player2Scored()
    {
        player2Score++;
        player2Text.GetComponent<TextMeshProUGUI>().text = player2Score.ToString();
        ball.GetComponent<Ball>().Reset();
    }
    
}