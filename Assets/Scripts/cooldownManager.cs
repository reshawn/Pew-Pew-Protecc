using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cooldownManager : MonoBehaviour {
	 

	public bool canFire;
	public Image cdBar;

	// Use this for initialization
	void Start () {
		// mainCam = GameObject.Find("Main Camera");
        // shootscript = mainCam.GetComponent<webCamScript>();
		// cdBar.type = Image.Type.Filled;
		// cdBar.fillAmount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		// canFire = shootscript.canFire;
		// Debug.Log(shootscript.canFire);
		// if(canFire == false){
		// 	elapsedTime = 0.5f;
		// 	cdBar.fillAmount = 1;
		// 	while(elapsedTime > 0){
		// 		elapsedTime -= Time.deltaTime;
		// 		cdBar.fillAmount = elapsedTime;
		// 	}
		// }
		// cdBar.fillAmount = 0;
	}
}
