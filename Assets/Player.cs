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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
        //ssasdasdasd
        transform.localPosition = new Vector3(clampXPos, clampYPos, transform.localPosition.z);
        
    }
}
