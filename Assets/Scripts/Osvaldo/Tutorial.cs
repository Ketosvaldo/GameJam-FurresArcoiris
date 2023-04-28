using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public Text textBox;
    public string[] instructions;
    int counter = 0;
    GeneradorDeEventos GM;
    public GameObject circuloReactor;
    public GameObject circuloTimon;
    public GameObject circuloFinal;

    private void Start()
    {
        textBox.text = instructions[counter];
        Movement.canMove = false;
        GM = FindObjectOfType<GeneradorDeEventos>();
    }
    void Steps()
    {
        switch (counter)
        {
            case 1: Movement.canMove = true; break;
            case 3: GM.reactorAlert.SetActive(true); GeneradorDeEventos.reactorIsActive = true; break;
            case 6: circuloReactor.SetActive(true); break;
            case 7: circuloReactor.SetActive(false); break;
            case 12: GM.reactorAlert.SetActive(false); GeneradorDeEventos.reactorIsActive = false; break;
            case 13: GM.simonAlert.SetActive(true); GeneradorDeEventos.simonIsActive = true; break;
            case 15: circuloTimon.SetActive(true); break;
            case 16: circuloTimon.SetActive(false); break;
            case 17: GM.simonAlert.SetActive(false); GeneradorDeEventos.simonIsActive = false; break;
            case 19: GM.bathroomAlert.SetActive(true); GeneradorDeEventos.bathroomIsActive = true; break;
            case 24: GM.bathroomAlert.SetActive(false); GeneradorDeEventos.bathroomIsActive = false; break;
            case 29: SceneManager.LoadScene("Menu"); break;
        }
    }
    public void NextStep()
    {
        counter++;
        textBox.text = instructions[counter];
        Steps();
    }

    
}
