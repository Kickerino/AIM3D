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
    private float fireSpellStart = 0f;
    private float fireSpellCooldown = 2f;
    private float windSpellStart = 0f;
    private float windSpellCooldown = 2f;
    private float waterSpellStart = 0f;
    private float waterSpellCooldown = 2f;
    private float earthSpellStart = 0f;
    private float earthSpellCooldown = 2f;
    private bool CanUsespell = true;

    public Text fireText;
    public Text waterText;
    public Text windText;
    public Text earthText;
    
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            fireText.text = "Can Use" + CanUsespell;
            
            if (Time.time > fireSpellStart + fireSpellCooldown)
            {
                fireSpellStart = Time.time;
                CanUsespell = true;
                launchfire();
            }
            
        }
        
        if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            Debug.Log("Button A");
            earthText.text = "Button A";

            if (Time.time > earthSpellStart + earthSpellCooldown)
            {
                earthSpellStart = Time.time;

                launchEarth();
            } 
        }
        
        if (Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            Debug.Log("Button X");
            waterText.text = "Button X";
            if (Time.time > waterSpellStart + waterSpellCooldown)
            {
                waterSpellStart = Time.time;

                launchWater();
            }
        }
        
        if (Input.GetKeyDown(KeyCode.JoystickButton3))
        {
            Debug.Log("Button Y");
            windText.text = "Button Y";
            if (Time.time > windSpellStart + windSpellCooldown)
            {
                windSpellStart = Time.time;

                launchAir();
            }
            
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


    void launchWater()
    {
        Rigidbody Bulletinstance;
        Bulletinstance = Instantiate(BulletWater, WandEnd.position, WandEnd.rotation) as Rigidbody;
        Bulletinstance.AddForce(WandEnd.forward * 5000);
    }
    void launchfire()
    {
        Rigidbody Bulletinstance;
        Bulletinstance = Instantiate(BulletFire, WandEnd.position, WandEnd.rotation) as Rigidbody;
        Bulletinstance.AddForce(WandEnd.forward * 5000);
    }
    void launchAir()
    {
        Rigidbody Bulletinstance;
        Bulletinstance = Instantiate(BulletAir, WandEnd.position, WandEnd.rotation) as Rigidbody;
        Bulletinstance.AddForce(WandEnd.forward * 5000);
    }
    void launchEarth()
    {
        Rigidbody Bulletinstance;
        Bulletinstance = Instantiate(BulletEarth, WandEnd.position, WandEnd.rotation) as Rigidbody;
        Bulletinstance.AddForce(WandEnd.forward * 5000);
    }
}
