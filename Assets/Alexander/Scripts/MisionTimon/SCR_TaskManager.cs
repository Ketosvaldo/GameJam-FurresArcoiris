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
    public bool enable = true;

    public void SelectButton()
    {
        randomButtons = Random.Range(0, 4); //variable random que elige algun boton
        if (!buttons[randomButtons].win)
        {
            buttons[randomButtons].isSelect = true;

            counter++;
        }
        else if(counter != 4)
        {
            SelectButton();
        }
        else
        {
            panel.SetActive(false);
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].isSelect = false;
                buttons[i].win = false;
                buttons[i].timeToLose = 0;
                buttons[i].timeToWin = 0;
                buttons[i].isTimer = false;
            }
            counter = 0;
            SelectButton();
        }
    }


}
