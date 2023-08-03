using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SCR_Button : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float timeToWin = 0; //contador de tiempo presionado del boton
    public float timeToLose = 0; //variable que aumenta su valor con respecto al tiempo para señalar que el jugador a perdido
    public bool isTimer; //boolean que verifica si el boton esta presionado

    public bool win;
    public bool onGame; //condicion de superar la prueba del boton 
    private SCR_TaskManager taskManager; //referencia del task manager
    public GameObject over; //objeto que hace que el boton se remarque

    SFX_Controller sfx;

    bool reproducedClip;
    private void Start()
    {
        taskManager = FindObjectOfType<SCR_TaskManager>();
        sfx = FindObjectOfType<SFX_Controller>();
    }

    private void Update()
    {
        if (onGame)
        {
            timeToLose += Time.deltaTime; //inicio del contador para perder
            if (!reproducedClip)
            {
                sfx.PlayAudio(6);
                reproducedClip = true;
            }
        }

        if (isTimer) //aumenta cuando presionas el boton
        {
            timeToWin += Time.deltaTime;
        }

        if (timeToWin >= 2.0f)
        {
            taskManager.SelectButton();
            reproducedClip = false;
            Restart();
            over.SetActive(false);
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

    public void ButtonMision()
    {
        over.SetActive(true); //el boton esta habilitado para usarse
        
        onGame = true;
    }

    private void Restart()
    {
        timeToLose = 0;
        timeToWin = 0;
        isTimer = false;
        onGame = false;
        //taskManager.enable = true;
    }


}
