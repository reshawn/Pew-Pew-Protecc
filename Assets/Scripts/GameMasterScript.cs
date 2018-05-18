using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMasterScript : MonoBehaviour {

	public float gameMusic;
	public float soundEffects;
	public float menuMusic;
	public Slider slider;
	public GameObject canvas;
	private AudioSource menu;
	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad(this);
		gameMusic = 1;
		canvas = GameObject.Find("Canvas");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void updateVolume(){
		gameMusic = slider.value;
		menuMusic = slider.value;
		menu = canvas.GetComponent<AudioSource>();
		menu.volume = menuMusic;
		Debug.Log(menuMusic);
		
	}
}
