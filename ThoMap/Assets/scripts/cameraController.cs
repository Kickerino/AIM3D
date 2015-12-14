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
    public Text myText;
    
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            Debug.Log("Button B");
            myText.text = "Button B";
            launchfire();
        }
        
        if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            Debug.Log("Button A");
            myText.text = "Button A";
            launchEarth();
        }
        
        if (Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            Debug.Log("Button X");
            myText.text = "Button X";
            launchWater();
        }
        
        if (Input.GetKeyDown(KeyCode.JoystickButton3))
        {
            Debug.Log("Button Y");
            myText.text = "Button Y";
            launchAir();
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
