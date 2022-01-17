using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    
    /*private void OnCollisionEnter(Collision collision)
    {
        print("Destroy");
    }*/
    private void OnTriggerEnter(Collider other)
    {
        print("HIT");
    }
}
