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

    SFX_Controller sfx;

    bool waitFinish;

    public Text textoDeVictoria;

    private void Start()
    {
        SelectButton();
        eventGenerator = FindObjectOfType<GeneradorDeEventos>();
        sfx = FindObjectOfType<SFX_Controller>();
    }

    private void Update()
    {
        if (count == 4 && !waitFinish)
        {
            GeneradorDeEventos.simonIsActive = false;
            GeneradorDeEventos.simonTimer = eventGenerator.simonDelay;
            Movement.canMove = true;
            sfx.PlayAudio(4);
            count = 0;
            waitFinish = true;
            textoDeVictoria.gameObject.SetActive(true);
            Invoke("DeactivatePanel", 2);
        }
    }

    public void SelectButton()
    {
        //randomButtons = Random.Range(0, 4); //variable random que elige algun boton
        buttons[count].ButtonMision();
        count++;
    }

    void DeactivatePanel()
    {
        textoDeVictoria.gameObject.SetActive(false);
        waitFinish = false;
        panel.SetActive(false);
    }
}
