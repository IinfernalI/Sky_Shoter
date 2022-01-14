using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    //обьявляем поле типа InputAction для возможности движения
    [SerializeField] private InputAction movement;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable() //Метод для включения работает после Awaik метода 
    {
        movement.Enable();// включаем это поле для работы
    }

    private void OnDisable() //Метод для выключения чего либо работает один из последних
    {
        movement.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        //Назначаем двум полям значения из поля movement что бы работать с ними по 2D вектору
        float horisontalMove = movement.ReadValue<Vector2>().x;
        float vertivalMove = movement.ReadValue<Vector2>().y;
    }
}
