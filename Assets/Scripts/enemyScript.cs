
using UnityEngine;
using System.Collections;

public class enemyScript : MonoBehaviour
{


    public float speed = 2f;
    public int hp = 2;
    public GameObject gamescore;
    scoreScript scorescript;    
    public GameObject canvas;  
    Player playerScript;
    string type;

    bool slideLeft = false, slideRight = false;
    // Use this for initialization
    void Start()
    {

        // StartCoroutine("Move");
        canvas = GameObject.Find("Canvas");
        playerScript = canvas.GetComponent<Player>();
        gamescore = GameObject.Find("GameScore");
        scorescript = gamescore.GetComponent<scoreScript>();

        enemyType et = this.gameObject.GetComponent<enemyType>();
        type = et.getType();
        if(string.Compare(type,"slideInDemDMs", true)==0){
            StartCoroutine(slide());
        }
        

 
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Translate(Vector3.forward * 3f * Time.deltaTime);
        float step = speed * Time.deltaTime;
        if(slideRight){
            transform.Translate(Vector3.right * step * 16);
        }
        else if (slideLeft){
            transform.Translate(-Vector3.right * step * 16);
        }
        transform.position = Vector3.MoveTowards(transform.position, Camera.main.transform.position, step);
    }

    public void changeMatDefault(Material mat){
        //get mesh renderer attached to ship prefab and load material based on arg
        //would need to be changed to reflect new model
        Renderer rend = transform.GetChild(0).Find("default").gameObject.GetComponent<Renderer>();
        
        // Material newmat = Resources.Load(mat, typeof(Material)) as Material;
        // rend.material = newmat;

        // GameObject boo = newEnemy.gameObject.transform.GetChild(0).GetChild(0).gameObject;
        
        Material[] mats = rend.materials;
        mats[0] = mat;
        rend.materials = mats;

        
        
    }

    public Material getMat(){
        Renderer rend = transform.GetChild(0).Find("default").gameObject.GetComponent<Renderer>();
        Material[] mat = rend.materials;
        return mat[0];
    }
    
    //called in collision script when enemy is hit by bullet
    public void hit(){
        hp--;
        StartCoroutine(hitFlash());
        if (hp==0){
            scorescript.incrementScore();
            scorescript.setScoreText();
            GameObject explosion = Instantiate(Resources.Load("Explosion", typeof(GameObject))) as GameObject;
            explosion.transform.position = transform.position;
            explosion.transform.LookAt(Camera.main.transform);
            goBoom();
            //turn off mesh renderer so itd look like enemy boomed but leave object alive for a while
            //so audio for destroy can play out
            hide();
            // this.gameObject.SetActive(false);
            Destroy(this.gameObject,2);
            Destroy (explosion, 1);
            
        }
    }
    public void hitPlayer(){ //enemy has reached player cam, diff animation may be used
        // GameObject explosion = Instantiate(Resources.Load("FlareMobile", typeof(GameObject))) as GameObject;
        // explosion.transform.position = transform.position;
        
        hide();
        Destroy(this.gameObject,2);
        playerScript.setPlayerDead(true);
        // Destroy (explosion, 2);
    }
    public void goBoom(){
        AudioSource[] audio = this.gameObject.GetComponents<AudioSource>();
        AudioSource boom = audio[2];
        boom.Play();
    }
    public void hide(){
        BoxCollider bcol = this.gameObject.GetComponent<BoxCollider>();
        bcol.enabled = false;
        Component[] rends;
        rends = GetComponentsInChildren(typeof(MeshRenderer));
        foreach (MeshRenderer rend in rends){
            rend.enabled = false;
        }
    }

    IEnumerator hitFlash(){
        Material flash = Resources.Load("Materials/hitMat", typeof(Material)) as Material;
        Material original = getMat();
        changeMatDefault(flash);
        yield return new WaitForSeconds(.2f);
        changeMatDefault(original);
    }

    IEnumerator slide(){
        yield return new WaitForSeconds(1);
        slideRight = true;
        yield return new WaitForSeconds(0.1f);
        slideRight = false;
        slideLeft = true;
        yield return new WaitForSeconds(0.2f);
        slideLeft = false;
        slideRight = true;
        yield return new WaitForSeconds(0.1f);
        slideRight = false;

        //again
        yield return new WaitForSeconds(1);
        slideRight = true;
        yield return new WaitForSeconds(0.1f);
        slideRight = false;
        slideLeft = true;
        yield return new WaitForSeconds(0.2f);
        slideLeft = false;
        slideRight = true;
        yield return new WaitForSeconds(0.1f);
        slideRight = false;


    }
}