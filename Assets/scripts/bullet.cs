using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
    public float lifetime = 6.0f;
    public GameObject explosion;

    void Awake()
    {
        Destroy(gameObject, lifetime);
    }

    void OnCollisionEnter(Collision coll) 
    {
        if(coll.gameObject.tag == "house")
        {
            Instantiate(explosion, transform.position, Quaternion.Euler(0, 270, 0));
            Destroy(this.gameObject);
        }
        if (coll.gameObject.tag == "HouseFire")
        {
            Instantiate(explosion, transform.position, Quaternion.Euler(0, 270, 0));
            Destroy(this.gameObject);
            Destroy(coll.gameObject);
        }
        if (coll.gameObject.tag == "HousePlague")
        {
            Instantiate(explosion, transform.position, Quaternion.Euler(0, 270, 0));
            Destroy(this.gameObject);
            Destroy(coll.gameObject);
        }
        if (coll.gameObject.tag == "HousePlaag")
        {
            Instantiate(explosion, transform.position, Quaternion.Euler(0, 270, 0));
            Destroy(this.gameObject);
            Destroy(coll.gameObject);
        }

    }
}