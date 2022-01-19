using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject deathFX;
    [SerializeField] private Transform parent;
    
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
        //берем заранее прикрепленный префаб взрыва в deathFX и переносим его в новый обьект GameObject
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity); //взрыв от обьекта
        fx.transform.parent = parent; //Присваеваем новый обьект в обьект родителя для удаления муссора
        
        Destroy(gameObject); 
        print("Kill" + gameObject.name);
    }
}
