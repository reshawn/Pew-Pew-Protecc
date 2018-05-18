using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSphereCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider col){
		if (col.gameObject.tag=="Enemy"){

			GameObject canvas = GameObject.Find("Canvas");
			Player playerscriptref = canvas.GetComponent<Player>();
			playerscriptref.setPlayerDead(true);

			enemyControl ec = Camera.main.GetComponent<enemyControl>();
			enemyScript es = col.gameObject.GetComponent<enemyScript>();
            ec.incHitCount(); // update count in control
			es.hitPlayer(); //destroy enemy that hit player
		}
	}
}
