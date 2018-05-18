using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnFaster : MonoBehaviour {

	// Use this for initialization
	enemyControl ecScript;
	float time;
	void Start () {
		ecScript = Camera.main.GetComponent<enemyControl>();
		
	}
	
	// Update is called once per frame
	void Update () {
		time = Time.timeSinceLevelLoad;
		float newSpawnTime = 4f;

	  if (time>=20&&time<40) newSpawnTime = 3f;
	  if (time>=40&&time<60) newSpawnTime = 2f;
	  if (time>=60) newSpawnTime = 1f;

		ecScript.spawnTime = newSpawnTime;
	}
}
