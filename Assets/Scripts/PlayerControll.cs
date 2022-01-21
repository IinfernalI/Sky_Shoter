using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
[DisallowMultipleComponent]
public class PlayerControll : MonoBehaviour
{
    //создаем переменные для скорости перемещений по X и по Y
    [Header("General")]
    [Tooltip("M/S")][SerializeField] private float xSpeed = 40f;
    [Tooltip("M/S")][SerializeField] private float ySpeed = 30f;
    [SerializeField] private GameObject[] guns;
    [Header("RangeFlyOnScreen")]
    //создаем переменные для ограничения максимального значения отдаления корабля относительно краев экрана
    [SerializeField] float xClamp = 13.5f;
    [SerializeField] float yClamp = 10.5f;
    [Header("StaticRotation")]
    //статический фактор вращения корабля относительно позиции на экране
    [SerializeField] private float xRotFactor = -2.5f;
    [SerializeField] private float yRotFactor = 1.5f;
    [Header("RotationOnMove")]
    //второй пропадающий фактор вращения относительно маневрирования корабля 
    [SerializeField] private float xMoveRotation = -10f;
    [SerializeField] private float yMoveRotation = 10f;
    [SerializeField] private float zMoveRotation = -15f;

    private bool isControllEnabled = true;
    private float xMove;
    private float yMove;
    
    void Update()
    {
        if (isControllEnabled)
        {
            MoveShip();
            RotateShip();
            FireGuns();
        }
    }

    void OnPlayerDeath()
    {
        isControllEnabled = false;
    }
    
    void MoveShip()
    {
        //создаем поля которые считывают нажатие осей и записываем их
        xMove = CrossPlatformInputManager.GetAxis("Horizontal");
        yMove = CrossPlatformInputManager.GetAxis("Vertical");
        
        //создаем поля в которые закидываем значения осей умноженные на скорость
        float xOffset = xMove * xSpeed * Time.deltaTime;
        float yOffset = yMove * ySpeed * Time.deltaTime;
        
        //создаем новые поля в которые забиваються значения прибавленные к осям + текущего положения оси
        float newXPos = transform.localPosition.x + xOffset;
        float newYPos = transform.localPosition.y + yOffset;
        
        //благодаря какой то матФормуле создаем обновленные значения полей для их ограничения 
        float clampXPos = Mathf.Clamp(newXPos, -xClamp, xClamp); //ограничение передвижения по экрану
        float clampYPos = Mathf.Clamp(newYPos, -yClamp, yClamp); //ограничение передвижения по экрану
        
        //заливаем уже обе готовые оси в новый вектор и в текущий трансформ , ось Z оставляем прежнюю иначе собьеться
        transform.localPosition = new Vector3(clampXPos, clampYPos, transform.localPosition.z);
    }

    void RotateShip()
    {   
        //для полного накрекренения в зависимости от расположенния на экране
        float xRot = transform.localPosition.y * xRotFactor + yMove * xMoveRotation;
        float yRot = transform.localPosition.x * yRotFactor + xMove * yMoveRotation;
        //для накренения корпуса во время поворота (временное значение в момент нажатия)
        float zRot = xMove * zMoveRotation;
        
        transform.localRotation = Quaternion.Euler(xRot,yRot,zRot);
    }

    void FireGuns()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            ActiveGuns();
        }
        else
        {
            DeactiveGuns();
        }
    }
    
    void ActiveGuns()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            foreach (GameObject gun in guns)
            {
                gun.SetActive(true);
            }
        }
    }

    void DeactiveGuns()
    {
        foreach (GameObject gun in guns)
        { 
            gun.SetActive(false);
        }
    }

    
}
