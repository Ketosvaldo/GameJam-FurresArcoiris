using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SCR_Button : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private float timeToWin = 0; //contador de tiempo presionado del boton
    private float timeToLose = 0; 
    private bool isTimer; //boolean que verifica si el boton esta presionado


    public bool isSelect;
    public bool win;
    private SCR_TaskManager taskManager;

    private void Start()
    {
        taskManager = FindObjectOfType<SCR_TaskManager>();
    }

    private void Update()
    {
        if (isSelect && !win)
        {
            timeToLose += 1 * Time.deltaTime;

            if (timeToLose - timeToWin >= 7)
            {
                isSelect = false;
            }
            else if (timeToWin >= 3.0f)
            {
                win = true;
                taskManager.SelectButton();
            }
            if (isTimer && timeToWin <= 3.0f) //condicion: si el boolean es verdadero, y si el tiempo de presionado es menor a 3
            {
                timeToWin += 1 * Time.deltaTime;
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isTimer = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isTimer = false;
    }

}
