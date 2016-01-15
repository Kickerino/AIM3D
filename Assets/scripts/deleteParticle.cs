using UnityEngine;
using System.Collections;

public class deleteParticle : MonoBehaviour {
    public float lifetime = 1.0f;

    void Awake()
    {
        Destroy(gameObject, lifetime);
    }

}
