using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("В секундах")][SerializeField] private float _loadLevelDelay = 2f;
    [Tooltip("Префаб эффекта взрыва")][SerializeField] private GameObject _explosionFX;
    [SerializeField] private PlayerControll _playerController;
    
    /*private void OnCollisionEnter(Collision collision)
    {
        print("Destroy");
    }*/
    private void OnTriggerEnter(Collider other)
    {
        print("HIT");
        StartDeath();
        _explosionFX.SetActive(true);
        Invoke("RestartLevel",_loadLevelDelay);
    }

    void StartDeath()
    {
        _playerController.OnPlayerDeath();
        //метод который ищет и запускает указанный метод на данном обьекте если он есть 
        //SendMessage("OnPlayerDeath");
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(1);
    }
}
