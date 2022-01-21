using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject deathFX;
    [SerializeField] private Transform parent;
    [SerializeField] private int scorePerHit = 10;
    [SerializeField] private int hits = 20;
    [SerializeField] private int damage = 10;

    private Score scoreObj;
    
    // Start is called before the first frame update
    void Start()
    
    {
        scoreObj = FindObjectOfType<Score>();
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
        scoreObj.ScoreHit(scorePerHit);
        print("hit" + gameObject.name);
        hits -= damage;
        if (hits <= 0 )
        {
            Death();Death();
        }
    }

    void Death()
    {
        //берем заранее прикрепленный префаб взрыва в deathFX и переносим его в новый обьект GameObject
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity); //взрыв от обьекта
        fx.transform.parent = parent; //Присваеваем новый обьект в обьект родителя для удаления муссора

        Destroy(gameObject);
        print("Dead" + gameObject.name);
    }
}
