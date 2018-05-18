using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

	Animator anim;
	public float restartDelay = 20f;
	float restartTimer;
	public GameObject canvas;
	Player playerscriptref;
	//instantiate player health trigger variable

	// Use this for initialization

	void Awake()
	{
		anim = GetComponent<Animator>();
		canvas = GameObject.Find("Canvas");
		playerscriptref = canvas.GetComponent<Player>();
	}

	void Update()
	{
		
		if(playerscriptref.playerDead == true)
			StartCoroutine(runGameOverAnimation());
	}

	IEnumerator runGameOverAnimation(){
			//yield return new WaitForSeconds(2);
			//anim.SetTrigger("GameOver");
			anim.Play("GameOverAnimation");
			restartTimer += Time.deltaTime;
			yield return new WaitForSeconds(2);

			// if(restartTimer >= restartDelay)
			// {
			// 	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
			// }
	}

	public void replayGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}
}
