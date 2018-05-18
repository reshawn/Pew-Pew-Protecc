using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class webCamScript : MonoBehaviour {
    public GameObject webCameraPlane;
    public Button fireButton;
    GameObject cameraParent;

    public GameObject mainCam;
    Animator anim;
	webCamScript shootscript;
	float elapsedTime;
    public Image cdBar;
    //states and variables
    public bool canFire=true;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        cameraParent = new GameObject("CamParent");
        cameraParent.transform.position = this.transform.position;
        this.transform.parent = cameraParent.transform;
        cameraParent.transform.Rotate(Vector3.right, 90);
    
        Input.gyro.enabled = true;

        fireButton.onClick.AddListener (shoot);

        mainCam = GameObject.Find("Main Camera");
        //shootscript = mainCam.GetComponent<webCamScript>();
		cdBar.type = Image.Type.Filled;
		cdBar.fillAmount = 0;
        

        WebCamTexture webCameraTexture = new WebCamTexture();
        // Debug.Log(webCameraTexture.height);
        webCameraPlane.GetComponent<MeshRenderer>().material.mainTexture = webCameraTexture;
        webCameraTexture.Play();

    }

    void shoot(){
        if (canFire){
            canFire = false;
            StartCoroutine(cooldown());
            AudioSource src = GetComponent<AudioSource>();
            src.Play();
            GameObject bullet = Instantiate(Resources.Load("bullet", typeof(GameObject))) as GameObject;
            
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            bullet.transform.rotation = Camera.main.transform.rotation;
            bullet.transform.position = Camera.main.transform.position;
            Transform t = Camera.main.transform;
            rb.AddForce(Camera.main.transform.forward * 2000f);
            Destroy (bullet, 2);

            
        }

    }
    IEnumerator cooldown(){
        yield return new WaitForSecondsRealtime(0.5f);
        canFire = true;
        cdBar.fillAmount = 0;
        //anim.SetTrigger("coolDown");    
        anim.Play("cdBarAnimation");
        Debug.Log("escape");
       
    }

    // Update is called once per frame
    void Update () {
        Quaternion cameraRotation = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.y, -Input.gyro.attitude.z, -Input.gyro.attitude.w);
        this.transform.localRotation = cameraRotation;

        if (Input.touchCount>0 && Input.GetTouch(0).phase==TouchPhase.Began){
            shoot();
        }
    }
}
