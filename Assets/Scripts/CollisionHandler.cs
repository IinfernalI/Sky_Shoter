using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("В секундах")][SerializeField] private float LoadLevelDelay = 2f;
    [Tooltip("Префаб эффекта взрыва")][SerializeField] private GameObject ExplosionFX;
    
    
    /*private void OnCollisionEnter(Collision collision)
    {
        print("Destroy");
    }*/
    private void OnTriggerEnter(Collider other)
    {
        print("HIT");
        StartDeath();
        ExplosionFX.SetActive(true);
        Invoke("RestartLevel",LoadLevelDelay);
    }

    void StartDeath()
    {
        //метод который ищет и запускает указанный метод на данном обьекте если он есть 
        SendMessage("OnPlayerDeath");
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(1);
    }
}
