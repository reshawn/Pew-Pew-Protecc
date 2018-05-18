using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreScript : MonoBehaviour {
 	public int score;
 	public Text scoreText;
	// Use this for initialization
	void Start () {
		score = 0;
		scoreText = GameObject.Find("GameScore").GetComponent<Text>();
   		setScoreText();
	}
	
   public void setScoreText()
   {
    if(scoreText!=null){
      scoreText.text = "Score: " + score;
    }
    
   }

   public void incrementScore()
   {
	   score++;
   }
	// Update is called once per frame
	void Update () {
		
	}
}
