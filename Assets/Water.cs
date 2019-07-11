using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{




    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hit");
        Application.LoadLevel(Application.loadedLevel);
    }
}