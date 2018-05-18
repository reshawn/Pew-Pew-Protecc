using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyControl : MonoBehaviour {

	// Use this for initialization
	public int hitCount = 0;
    public bool firstSpawn = true;
    public float spawnTime = 4f;
	void Start () {

        StartCoroutine(spawnBegin());
	}
    
	IEnumerator spawnBegin(){
        while(true){
            float st;
            
            if (firstSpawn) {
                firstSpawn = false;
                st = 0;
            }
            else st = spawnTime;

            yield return new WaitForSeconds(st);
            StartCoroutine(spawnFinish());
           
            
         
        }
    }

    public void openPortalOnSpawn(Vector3 pos){

        GameObject portal = Instantiate(Resources.Load("portal", typeof(GameObject))) as GameObject;
        portal.transform.position = pos;
        portal.transform.position += Camera.main.transform.up;
        portal.transform.LookAt(Camera.main.transform);
        portal.transform.localScale = new Vector3(0,0,0);
        StartCoroutine(scalePortal(portal,0.5f, true));
        Destroy (portal, 3);
        return;
    }
    //i should really put better comments in this page while i still understand it monkaS
    IEnumerator scalePortal(GameObject portal, float duration, bool up){
        float t =0; float lerp;
        while (t<1){
            yield return new WaitForSeconds(0.05f);
            t += 0.05f / duration;
            if (up) lerp = Mathf.Lerp(0f,2f,t);
            else lerp = Mathf.Lerp(2f,0f,t);
            if (portal) portal.transform.localScale = new Vector3(lerp,lerp,0);
            else yield return null;
        }
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(scalePortal(portal,duration, false));
        yield return null;  
    }


    IEnumerator spawnFinish(){
        Vector3 newpos = getNewPos();
        openPortalOnSpawn(newpos);
        yield return new WaitForSeconds(1);

        
        //instantiate enemy model
        GameObject newEnemy = Instantiate(Resources.Load("Boo", typeof(GameObject))) as GameObject;
        // newEnemy.name = name;
        newEnemy.transform.position = newpos;
        randMat(newEnemy);//random material color

        

        newEnemy.transform.LookAt(Camera.main.transform, Camera.main.transform.up);
        newEnemy.tag = "Enemy";
        newEnemy.AddComponent(typeof(enemyScript));
        // newEnemy.AddComponent(typeof(BoxCollider));
        Rigidbody rb = newEnemy.AddComponent(typeof(Rigidbody)) as Rigidbody;
        rb.useGravity = false;

        //remember to attach audio component with source to new prefab
         //audio clip stuff
        AudioSource[] audio = newEnemy.GetComponents<AudioSource>();
        AudioSource spawn = audio[0];
        spawn.Play();
        

    }

    Vector3 getNewPos(){
        Vector3 newpos;
        AudioSource[] audio = Camera.main.GetComponents<AudioSource>();
        AudioSource alert = audio[1];
        float spawnType = Random.Range(0,10);//10% chance to spawn behind cam
        if (spawnType==11){
            //set spawn position - behind cam
            newpos = Random.insideUnitCircle * 10;
            newpos -= transform.forward * (Vector3.Distance(transform.Find("SpawnPlane").position,transform.position));
            // newpos = Vector3.MoveTowards(newpos, Camera.main.transform.position, 10);
            alert.Play();
        }
        else{
            //set spawn position - on plane
            getBounds gb = transform.Find("SpawnPlane").GetComponent<getBounds>();
            Vector3 max = gb.getMax();
            Vector3 min = gb.getMin();
            newpos = new Vector3((Random.Range(min.x,max.x)),(Random.Range(min.y,max.y)),(Random.Range(min.z,max.z)));
            // newpos = Vector3.MoveTowards(newpos, Camera.main.transform.position, 10);
            
        }
        return newpos;
    }

	public void incHitCount(){
		hitCount++;
	}

    public void randMat(GameObject newEnemy){
        GameObject boo = newEnemy.gameObject.transform.GetChild(0).GetChild(0).gameObject;
        Renderer rend = boo.GetComponent<Renderer>();
        Material[] mat = rend.materials;

        float rand = Random.Range(1,6);//max with int isnt inclusive
        Material randomMat = Resources.Load("Materials/mat"+rand.ToString(), typeof(Material)) as Material;

        mat[0] = randomMat;
        rend.materials = mat;
    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
