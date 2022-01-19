using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerColider();
        
    }

    /// <summary>
    /// Метод который добавляет бокс коллайдер если его нет и отключает триггер,
    /// или отключает триггер если бокс коллайдер уже есть.
    /// </summary>
    void AddNonTriggerColider()
    {
        if (gameObject.GetComponent<BoxCollider>() is null)
        {
            gameObject.AddComponent<BoxCollider>();
            gameObject.AddComponent<BoxCollider>().isTrigger = false;
        }
        else
        {
            gameObject.GetComponent<BoxCollider>().isTrigger = false;
        }

        /*Collider boxCollider = gameObject.GetComponent<BoxCollider>();
        boxCollider.isTrigger = false;*/
    }

    
    private void OnParticleCollision(GameObject other)
    {
        print("Kill" + gameObject.name);
        Destroy(gameObject);
    }
}
