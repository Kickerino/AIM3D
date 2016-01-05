using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class cameraController : MonoBehaviour {

    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;
    public Rigidbody BulletFire;
    public Rigidbody BulletWater;
    public Rigidbody BulletAir;
    public Rigidbody BulletEarth;
    public Transform WandEnd;
    private bool CanUsesfire = true;
    private bool CanUsesair = true;
    private bool CanUsesearth = true;
    private bool CanUseswater = true;

    public Text fireText;
    public Text waterText;
    public Text windText;
    public Text earthText;

    IEnumerator fireShoot()
    {
        CanUsesfire = false;
        launchObject(BulletFire);
        yield return new WaitForSeconds(1.3f);
        CanUsesfire = true;  
    }
    IEnumerator airShoot()
    {
        CanUsesair = false;
        launchObject(BulletAir);
        yield return new WaitForSeconds(1.3f);
        CanUsesair = true;
    }
    IEnumerator earthShoot()
    {
        CanUsesearth = false;
        launchObject(BulletEarth);
        yield return new WaitForSeconds(1.3f);
        CanUsesearth = true;
    }
    IEnumerator waterShoot()
    {
        CanUseswater = false;
        launchObject(BulletWater);
        yield return new WaitForSeconds(1.3f);
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
        float h = horizontalSpeed * Input.GetAxis("Joystick X");
        //float v = verticalSpeed * Input.GetAxis("Joystick Y");
       
        if (h > 1)
        {
        transform.Rotate(0, h, 0);
        }
        else if(h < -1)
        {
        transform.Rotate(0, h, 0);
        }
	}

    void launchObject(Rigidbody ayy)
    {
        Rigidbody Bulletinstance;
        Bulletinstance = Instantiate(ayy, WandEnd.position, WandEnd.rotation) as Rigidbody;
        Bulletinstance.AddForce(WandEnd.forward * 5000);
    }
}
