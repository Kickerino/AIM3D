using UnityEngine;
using System.Collections;

public class deleteParticle : MonoBehaviour {
    public float lifetime = 1.0f;
	// Use this for initialization
	void Start () {
	
	}
    void Awake()
    {
        Destroy(gameObject, lifetime);
    }
	// Update is called once per frame
	void Update () {
	
	}
}
