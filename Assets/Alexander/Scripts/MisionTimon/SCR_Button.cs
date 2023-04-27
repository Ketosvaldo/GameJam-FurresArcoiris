using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SCR_Button : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float timeToWin = 0; //contador de tiempo presionado del boton
    public float timeToLose = 0; //variable que aumenta su valor con respecto al tiempo para señalar que el jugador a perdido
    public bool isTimer; //boolean que verifica si el boton esta presionado


    public bool isSelect; //variable que funciona para decir que esta seleccionado o fue seleccionada antes
    public bool win; //condicion de superar la prueba del boton 
    private SCR_TaskManager taskManager; //referencia del task manager
    public GameObject over; //objeto que hace que el boton se remarque

    private void Start()
    {
        taskManager = FindObjectOfType<SCR_TaskManager>();

    }

    private void Update()
    {
        if (isSelect && !win)
        {
            over.SetActive(true); //el boton esta habilitado para usarse

            timeToLose += 1 * Time.deltaTime; //inicio del contador para perder

            if (timeToLose - timeToWin >= 7)
            {
                isSelect = false; //se ha superado el tiempo para superar el boton, el jugador pierde
                taskManager.panel.SetActive(false);

                /*resets*/
                win = false;
                isSelect = false;
                timeToLose = 0;
                timeToWin = 0;
                isTimer = false;
            }
            else if (timeToWin >= 3.0f)
            {
                win = true; //se ha superado el tiempo para superar el boton, el jugador gana
                taskManager.SelectButton(); //llama a la funcion "SelectButton()" del "SCR_TaskManager" para pasar al siguiente boton
                over.SetActive(false);
            }
            if (isTimer && timeToWin <= 3.0f) //condicion: si el boolean es verdadero, y si el tiempo de presionado es menor a 3
            {
                timeToWin += 1 * Time.deltaTime; //el tiempo que pasa el jugador presionando el boton
            }
        }
    }

    /*funcion que detecta cuando el boton esta siendo presionado*/
    public void OnPointerDown(PointerEventData eventData)
    {
        isTimer = true;
    }

    /*funcion que detecta cuando el boton se deja de presionar*/
    public void OnPointerUp(PointerEventData eventData)
    {
        isTimer = false;
    }

}
