using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;

public class GameOverManager : MonoBehaviour {

	Animator anim;
	public float restartDelay = 20f;
	float restartTimer;
	public GameObject canvas;
	Player playerscriptref;
	InterstitialAd interstitial;
	bool once;
	//instantiate player health trigger variable

	// Use this for initialization

	void Awake()
	{
		anim = GetComponent<Animator>();
		canvas = GameObject.Find("Canvas");
		playerscriptref = canvas.GetComponent<Player>();
		once = true;
		RequestInterstitial();
	}

	void Update()
	{
		
		if(playerscriptref.playerDead == true && once==true){
			once = false;
			Debug.Log(once);
			StartCoroutine(runGameOverAnimation());
			
		}
	}

	IEnumerator runGameOverAnimation(){
		Object[] objs = (Object.FindObjectsOfType(typeof(AudioSource)));
		foreach(Object ob in objs){
			Destroy(ob);
		}
		//yield return new WaitForSeconds(2);
		//anim.SetTrigger("GameOver");
		anim.Play("GameOverAnimation");
		restartTimer += Time.deltaTime;
		yield return new WaitForSeconds(0.75f);
		if (interstitial.IsLoaded()) {
				interstitial.Show();
		}
		// if(restartTimer >= restartDelay)
		// {
		// 	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		// }
	}

	public void replayGame()
	{
		// interstitial.Destroy();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	public void backToMenu()
	{
		// interstitial.Destroy();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}

	private void RequestInterstitial()
	{
		//if UNITY_ANDROID
		string adUnitId = "ca-app-pub-4383007235464103/2448313339"; // real ad
		// string adUnitId = "ca-app-pub-3940256099942544/1033173712"; // test ad

		// Initialize an InterstitialAd.
		interstitial = new InterstitialAd(adUnitId);
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
		// Load the interstitial with the request.
		interstitial.LoadAd(request);
	}
}
