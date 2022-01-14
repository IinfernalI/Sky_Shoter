using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    //создаем переменные для скорости перемещений по X и по Y
    [Tooltip("M/S")][SerializeField] private float xSpeed = 40f;
    [Tooltip("M/S")][SerializeField] private float ySpeed = 30f;
    
    //создаем переменные для ограничения максимального значения
    [SerializeField] float xClamp = 12.5f;
    [SerializeField] float yClamp = 9f;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        MoveShip();
        RotateShip();
        
    }

    void MoveShip()
    {
        //создаем поля которые считывают нажатие осей и записываем их
        float xMove = CrossPlatformInputManager.GetAxis("Horizontal");
        float yMove = CrossPlatformInputManager.GetAxis("Vertical");
        
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
        transform.localRotation = Quaternion.Euler(30,30,0);
    }
}
