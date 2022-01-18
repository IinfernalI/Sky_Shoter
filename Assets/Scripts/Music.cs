using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private void Awake()
    {
        int numMusic = FindObjectsOfType<Music>().Length;
        DontDestroyOnLoad(gameObject);
        if (numMusic > 1)
        {
            Destroy(gameObject);
        }
        /*if (FindObjectsOfType<Music>().Length > 0)
        {
            for (int i = FindObjectsOfType<Music>().Length; i > 1; i--)
            {
                Destroy(gameObject);
            }
        }*/
    }
}
