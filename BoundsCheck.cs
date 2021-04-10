using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Предотвращает выход игрового обьекта за границы экрана.
/// Важно, работает только с ортографической камерой Main Camera в [0,0,0].
/// </summary>

public class BoundsCheck : MonoBehaviour
{  
    [Header("Set in Inspector")]
    public float radius = 1f;
    public bool keepOnScreen = true;


    [Header("Set Dynamically")]
    public bool isOnScreen = true;
    public float camWidth;
    public float camHeigth;
    [HideInInspector]
    public bool offRight, offLeft, offUp, offDown;

    private void Awake()
    {
        camHeigth = Camera.main.orthographicSize;
        camWidth = camHeigth * Camera.main.aspect;
        
    }

   

   
    void LateUpdate()
    {
        Vector3 pos = transform.position;
        isOnScreen = true;
        offRight = offLeft = offUp = offDown = false;
        if (pos.x > camWidth - radius)
        {
            pos.x = camWidth - radius;
            offRight = true;
        }
        if (pos.x < -camWidth + radius)
        {
            pos.x = -camWidth + radius;
            offLeft = true;
        }
        if  (pos.y > camHeigth - radius)
        {
            pos.y = camHeigth - radius;
            offUp = true;
        }
        if (pos.y < -camHeigth + radius)
        {
            pos.y = -camHeigth + radius;
            offDown = true;
        }
        isOnScreen = !(offRight || offLeft || offUp || offDown);
        if(keepOnScreen && !isOnScreen)
        {
            transform.position = pos;
            isOnScreen = true;
            offRight = offLeft = offUp = offDown = false;
        }
        
    }
   
    }
}
