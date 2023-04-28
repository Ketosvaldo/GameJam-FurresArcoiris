using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCR_TaskManager : MonoBehaviour
{
    [SerializeField] public  SCR_Button[] buttons; //arreglo de botones. Agregar manualmente desde el inspector
    private int randomButtons;
    [SerializeField] public int count = 0;

    public GameObject panel;

    private GeneradorDeEventos eventGenerator;

    private void Start()
    {
        SelectButton();
        eventGenerator = FindObjectOfType<GeneradorDeEventos>();
    }

    private void Update()
    {
        if (count == 4)
        {
            GeneradorDeEventos.simonIsActive = false;
            GeneradorDeEventos.simonTimer = eventGenerator.simonDelay;
            Movement.canMove = true;
            count = 0;
            panel.SetActive(false);
        }
    }

    public void SelectButton()
    {
        //randomButtons = Random.Range(0, 4); //variable random que elige algun boton
        buttons[count].ButtonMision();
        count++;
    }
}
