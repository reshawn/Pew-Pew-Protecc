using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.AudioSource;

public class Player : MonoBehaviour {


	public bool playerDead;
	// public GameObject canvas;
	private GameObject gameMaster;
	GameMasterScript masterSoundScript;
	private AudioSource gameMusic;

	// Use this for initialization
	void Start () {
		playerDead = false;
		gameMaster = GameObject.Find("GameMaster");
		masterSoundScript = gameMaster.GetComponent<GameMasterScript>();
		gameMusic = GetComponent<AudioSource>();
		gameMusic.volume = masterSoundScript.gameMusic;
		//Debug.Log(gameMusic.volume + " gamemusic and " + masterSoundScript.gameMusic);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setPlayerDead(bool state){
		this.playerDead = state;
	}
}
