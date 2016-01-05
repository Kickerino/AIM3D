using UnityEngine;
using System.Collections;

public class randomDisasters : MonoBehaviour {
    private bool isDiseased = false;
    private bool isPlaag = false;
    public bool isFire = false;
    private bool timer = false;
    private float fireSpellStart = 0f;
    private float fireSpellCooldown = 3f;
    public ParticleSystem HouseFire;
    public ParticleSystem HousePlague;
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "WaterBullet" && isFire == true)
        {
            //this.gameObject.GetComponent<ParticleSystem>().enableEmission = false;
            isFire = false;
        }
        if (coll.gameObject.tag == "FireBullet" && isDiseased == true)
        {
            isDiseased = false;
        }

    }

    void Disease() 
    {
        isDiseased = true;
        Instantiate(HousePlague, transform.position, Quaternion.identity);
    }

    void plaag() 
    {
        isPlaag = true;

    }
    void Fire() 
    {
        isFire = true;
        Instantiate(HouseFire, transform.position, Quaternion.identity);

    }

    void Update() 
    {
        if (Time.time > fireSpellStart + fireSpellCooldown)
        {
            fireSpellStart = Time.time;
            randomNumber();
        }
    }
    void randomNumber(){
        int index;
        index = Random.Range(0, 3);
        if (index == 0 && isDiseased == false && isFire == false)
        {
            Disease();
            isDiseased = true;
        }
        else if (index == 1 && isPlaag == false)
        {
            plaag();
            isPlaag = true;
        }
        else if (index == 2 && isFire == false && isDiseased == false)
        {
            Fire();
            isFire = true;
        }
        else
        {
            Debug.Log("Somthing Gooood");
        }
        Debug.Log(index);
    }
}
