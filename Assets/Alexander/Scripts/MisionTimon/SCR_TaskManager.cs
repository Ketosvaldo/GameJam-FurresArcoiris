using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCR_TaskManager : MonoBehaviour
{
    [SerializeField] public  SCR_Button[] buttons; //arreglo de botones. Agregar manualmente desde el inspector
    private int randomButtons;

    public GameObject panel;
    public int counter = 0;

    private void Start()
    {
        SelectButton();
    }

    public void SelectButton()
    {
        //Debug.Log(counter);
        randomButtons = Random.Range(0, 4); //variable random que elige algun boton
        if (!buttons[randomButtons].win)
        {
            buttons[randomButtons].isSelect = true;
            //Debug.Log("Button" + buttons[randomButtons].name + " Activado");

            counter++;
        }
        else if(counter != 4)
        {
            SelectButton();
        }
        else
        {
            panel.SetActive(false);
        }
    }


}
