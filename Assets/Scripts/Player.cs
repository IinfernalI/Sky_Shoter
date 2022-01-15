using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
[DisallowMultipleComponent]
public class Player : MonoBehaviour
{
    //создаем переменные для скорости перемещений по X и по Y
    [Tooltip("M/S")][SerializeField] private float xSpeed = 40f;
    [Tooltip("M/S")][SerializeField] private float ySpeed = 30f;
    
    //создаем переменные для ограничения максимального значения
    [SerializeField] float xClamp = 13.5f;
    [SerializeField] float yClamp = 10.5f;

    [SerializeField] private float xRotFactor = -2.5f;
    [SerializeField] private float yRotFactor = 1.5f;

    [SerializeField] private float xMoveRotation = -10f;
    [SerializeField] private float yMoveRotation = 10f;
    [SerializeField] private float zMoveRotation = -15f;

    private float xMove;
    private float yMove;
    
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
        //для накренения корпуса во время поворота
        float zRot = xMove * zMoveRotation;
        
        transform.localRotation = Quaternion.Euler(xRot,yRot,zRot);
    }
}
