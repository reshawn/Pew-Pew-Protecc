using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getBounds : MonoBehaviour {

	public Renderer rend;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//bounding x of plane
	public Vector3 getMax(){
		rend = GetComponent<Renderer>();
		//bounds.max returns to higher bounding x y z axes values for the plane
		//eg bound.max.x would be = ( transform.position.x + (transform.localScale.x*5)
		return (rend.bounds.max);
	}
	public Vector3 getMin(){
		rend = GetComponent<Renderer>();
		return (rend.bounds.min);
	}
}
