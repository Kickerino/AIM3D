using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
    public float lifetime = 6.0f;
    public GameObject explosion;

	void Start ()
    {
	
	}

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

    }
}