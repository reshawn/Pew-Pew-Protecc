using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class collisionScript : MonoBehaviour {
  

  // Use this for initialization
  void Start () {
    
  }

  // Update is called once per frame
  void Update () {

  }


  //for this to work both need colliders, one must have rigid body (spaceship) the other must have is trigger checked.
  void OnTriggerEnter (Collider col)
  {
    //call hit function of the enemy hit
    enemyScript es = col.gameObject.GetComponent<enemyScript>();
    es.hit();
    this.gameObject.GetComponent<MeshRenderer>().enabled = false;
    Destroy (gameObject, 2);


  }

}
