using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    ButtonMash cumple la funcionalidad de llevar a cabo la lógica y cálculos para la mecánica de mash así como el actualizar la barra indicadora.
*/

public class ButtonMash : MonoBehaviour
{
    public Slider slider; // Variable que se usa para enlazar el slider
    public GameObject youWinTextContainer; // Variable temporal para demostrar el funcionamiento de la mecánica
    public GameObject bathroomUI; //Variable para controlar la UI del baño
    private GeneradorDeEventos eventGenerator; //Referencia al generador de eventos
    HealthBar healthBar;

    public GameObject camera;
    public GameObject cameraTarget;

    public GameObject transitionObject;
    public GameObject cheetaBathroomAnim;

    public GameObject InteractableIconPlayer;

    bool hasClicked; // Se usa para llevar control de los clicks al botón
    bool hasSucceded; // Se usa para determinar si el jugador completó el minijuego
    float perClickValue = 0.2f; // Valor de cada click al botón
    float mashProgress = 0.0f; // Progreso del mash

    private void Start() {
        youWinTextContainer.SetActive(false); // Se usa para esconder el texto de prueba
        eventGenerator = FindObjectOfType<GeneradorDeEventos>();
        healthBar = FindObjectOfType<HealthBar>();
    }

    private void Update() {
        if(hasClicked){
            // Si el jugador hace click al botón se aumenta el progreso y se actualiza el slider
            mashProgress += perClickValue;
            UpdateBar();
            hasClicked = false; // Se usa para llevar control de los clicks
        }else if(!hasSucceded){
            mashProgress -= Time.deltaTime; // Cuando no hay información de click se disminuye el progreso y se actualiza el slider
            UpdateBar();
        }
        if(hasSucceded){
            BathroomMinigameEnd(); // Cuando se completa la barra acaba el minijuego
        }
    }

    public void ButtonClick(){
        hasClicked = true; // ButtonClick se usa para enlazar el script con los clicks del botón
    }

    public void UpdateBar(){
        // Se usa para actualizar el slider
        if(mashProgress > 1){
            mashProgress = 1;
            hasSucceded = true; // Si el slider pasa de 1 el jugador ha sido exitoso
        }else if (mashProgress < 0){
            mashProgress = 0; // Si el progreso es menor a 0 se iguala a 0 para limitarlo
        }
        slider.value = mashProgress; // Se actualiza el valor del slider
    }

    public void BathroomMinigameEnd() {
        //youWinTextContainer.SetActive(true); // Lógica temporal, será reemplazado con la lógica requerida por el manager de tareas
        GeneradorDeEventos.bathroomIsActive = false;
        GeneradorDeEventos.bathroomTimer = eventGenerator.bathroomDelay;
        hasSucceded=false;
        mashProgress=0;
        healthBar.repairDrain();
        bathroomUI.SetActive(false);
        BathroomTrigger.bathroomIsPlaying = false;
        cheetaBathroomAnim.SetActive(false);
        transitionObject.SetActive(true);
        Invoke("moveCamera", 1);
        InteractableIconPlayer.SetActive(false);
        
    }

    private void moveCamera(){
        camera.transform.position = cameraTarget.transform.position;
    }
}
