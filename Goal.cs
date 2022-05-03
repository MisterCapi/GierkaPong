using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool isPlayer1Goal;

    public GameObject player1;

    private void OnTriggerEnter2D(Collider2D other)
    {
	    if (other.gameObject.CompareTag("Ball"))
	    {
		    if (isPlayer1Goal)
		    {
			    GameObject.Find("GameManager").GetComponent<GameManager>().Player2Scored();
			    player1.SendMessage("Lose");
		    }
		    else
		    {
			    GameObject.Find("GameManager").GetComponent<GameManager>().Player1Scored();
		    }
	    }
    }
}
