using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyType : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public string getType(){
		float time = Time.timeSinceLevelLoad;
		string type = "normie";
		if (time>60){
			int randy = Random.Range(1,11);
			if(randy>=8 && randy<11){
				type = "slideInDemDMs";
			}
			
		}

		if (time > 120){
			int randy = Random.Range(1,11);
			if (randy>=1 && randy<=6){
				type = "slideInDemDMs";
			}
		}

		return type;

	}
}
