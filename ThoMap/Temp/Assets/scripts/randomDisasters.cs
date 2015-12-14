using UnityEngine;
using System.Collections;

public class randomDisasters : MonoBehaviour {
    private bool isDiseased = false;
    private bool isPlaag = false;
    private bool isFire = false;


    void Disease() 
    {
        isDiseased = true;

    }

    void plaag() 
    {
        isPlaag = true;

    }
    void Fire() 
    {
        isFire = true;

    }
}
