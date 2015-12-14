using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
    public float lifetime = 6.0f;

	void Start () {
	
	}

    void Awake()
    {
        Destroy(gameObject, lifetime);
    }
}
