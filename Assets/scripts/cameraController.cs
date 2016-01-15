using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class cameraController : MonoBehaviour {

    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;
    public Rigidbody BulletFire;
    public Rigidbody BulletWater;
    public Rigidbody BulletAir;
    public Rigidbody BulletEarth;
    public Transform WandEnd;
    private float ShootCoolDown = 1.3f;
    private bool CanUsesfire = true;
    private bool CanUsesair = true;
    private bool CanUsesearth = true;
    private bool CanUseswater = true;
    private int CheatSpam = 0;
    private int sceneToLoad;
    public Text fireText;
    public Text waterText;
    public Text windText;
    public Text earthText;
    public Text cheatActive;

    private AsyncOperation async;

    void Start()
    {
        CheatSpam = 0;
        ShootCoolDown = 1.3f;
    }
    IEnumerator fireShoot()
    {
        CanUsesfire = false;
        launchObject(BulletFire);
        yield return new WaitForSeconds(ShootCoolDown);
        CanUsesfire = true;  
    }
    IEnumerator airShoot()
    {
        CanUsesair = false;
        launchObject(BulletAir);
        yield return new WaitForSeconds(ShootCoolDown);
        CanUsesair = true;
    }
    IEnumerator earthShoot()
    {
        CanUsesearth = false;
        launchObject(BulletEarth);
        yield return new WaitForSeconds(ShootCoolDown);
        CanUsesearth = true;
    }
    IEnumerator waterShoot()
    {
        CanUseswater = false;
        launchObject(BulletWater);
        yield return new WaitForSeconds(ShootCoolDown);
        CanUseswater = true;
    }

	void Update () {
        fireText.text = "" + CanUsesfire;
        waterText.text = "" + CanUseswater;
        windText.text = "" + CanUsesair;
        earthText.text = "" + CanUsesearth;


        if (Input.GetKeyDown(KeyCode.JoystickButton1) && CanUsesfire == true)
        {
            StartCoroutine(fireShoot());
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton0) && CanUsesearth == true)
        {
            StartCoroutine(earthShoot()); 
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton2) && CanUseswater == true)
        {
            StartCoroutine(waterShoot());
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton3) && CanUsesair == true)
        {
            StartCoroutine(airShoot());
            
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            sceneToLoad = 0;
            StartCoroutine(LoadScene());
            NameChild.villagers = 25;

        }
        float h = horizontalSpeed * Input.GetAxis("Joystick X");
       
        if (h > 1)
        {
        transform.Rotate(0, h, 0);
        }
        else if(h < -1)
        {
        transform.Rotate(0, h, 0);
        }
        
        if (Input.GetKeyDown(KeyCode.JoystickButton6))
        {
            CheatSpam++;
            if (CheatSpam == 10) 
            {
                ShootCoolDown = 0.1f;
                cheatActive.text = "Bronzo Mode Active";
            }
        }
	}

    

    IEnumerator LoadScene() {
        async = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Single);
        while (!async.isDone) {
            yield return new WaitForEndOfFrame();
        }
    }

    void launchObject(Rigidbody ayy)
    {
        Rigidbody Bulletinstance;
        Bulletinstance = Instantiate(ayy, WandEnd.position, WandEnd.rotation) as Rigidbody;
        Bulletinstance.AddForce(WandEnd.forward * 5000);
    }

}
