using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class randomDisasters : MonoBehaviour {
    private bool isDiseased = false;
    private bool isPlaag = false;
    private bool isDestroyed = false;
    public bool isFire = false;
    private float fireSpellStart = 0f;
    private float fireSpellCooldown = 3f;
    public ParticleSystem HouseFire;
    public ParticleSystem HousePlague;
    public ParticleSystem Houseplaag;
    public ParticleSystem HouseDestroyed;
    public int Villagers = 25;
    public Text VillagerCount;
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "WaterBullet" && isFire == true)
        {
            isFire = false;
            FindClosestEnemyFire();

        }
        else if (coll.gameObject.tag == "WaterBullet" && isFire == false && isDiseased == false)
        {
            Disease();
        }
        if (coll.gameObject.tag == "FireBullet" && isDiseased == true)
        {
            isDiseased = false;
            FindClosestEnemyPlague();
        }
        else if (coll.gameObject.tag == "FireBullet" && isDiseased == false && isFire == false)
        {
            Fire();
        }
        if (coll.gameObject.tag == "AirBullet" && isPlaag == true)
        {
            isPlaag = false;
            FindClosestEnemyPlaag();
        }
        else if (coll.gameObject.tag == "AirBullet" && isPlaag == false && isPlaag == false)
        {
            plaag();
        }
        if (coll.gameObject.tag == "EarthBullet" && isDestroyed == true)
        {
            isDestroyed = false;
            FindClosestEnemyDestroyed();
        }
        else if (coll.gameObject.tag == "EarthBullet" && isDestroyed == false && isDestroyed == false)
        {
            Destroy();
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
        ParticleSystem childObject = Instantiate(Houseplaag, transform.position, Quaternion.Euler(-90, 0, 0)) as ParticleSystem;
    }
    void Fire() 
    {
        isFire = true;
        ParticleSystem childObject = Instantiate(HouseFire, transform.position, Quaternion.Euler(-90, 0, 0)) as ParticleSystem;
        childObject.transform.parent = this.gameObject.transform;
    }
    void Destroy()
    {
        isDestroyed = true;
        ParticleSystem childObject = Instantiate(HouseDestroyed, transform.position, Quaternion.Euler(-90, 0, 0)) as ParticleSystem;
        childObject.transform.parent = this.gameObject.transform;
    }

    void Update() 
    {
        if (Time.time > fireSpellStart + fireSpellCooldown)
        {
            fireSpellStart = Time.time;
            randomNumber();
            VillagerCount.text = "Villagers:" +" "+ NameChild.villagers + "/" + "25";
        }
        
        
    }
    void randomNumber(){
        int index;
        index = Random.Range(0, 4);
        if (index == 0 && isDiseased == false && isFire == false && isPlaag == false && isDestroyed == false)
        {
            Disease();
            isDiseased = true;
        }
        else if (index == 1 && isPlaag == false && isDiseased == false && isFire == false && isDestroyed == false)
        {
            plaag();
            isPlaag = true;
        }
        else if (index == 2 && isFire == false && isDiseased == false && isPlaag == false && isDestroyed == false)
        {
            Fire();
            isFire = true;
        }
        else if (index == 3 && isFire == false && isDiseased == false && isPlaag == false && isDestroyed == false)
        {
            Destroy();
            isDestroyed = true;
        }
    }
    GameObject FindClosestEnemyFire() {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("HouseFire");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos) {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance) {
                closest = go;
                distance = curDistance;
            }
        }
        Destroy(closest);
        return closest;
        
    }
    GameObject FindClosestEnemyPlague()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("HousePlague");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        Destroy(closest);
        return closest;

    }
    GameObject FindClosestEnemyPlaag()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("HousePlaag");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        Destroy(closest);
        return closest;

    }
    GameObject FindClosestEnemyDestroyed()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("HouseDestroyed");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        Destroy(closest);
        return closest;

    }


}
