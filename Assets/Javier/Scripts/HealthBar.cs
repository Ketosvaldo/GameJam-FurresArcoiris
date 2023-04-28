using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
    HealthBar toma un componente de slider y cambia el estado de progreso de la barra con el tiempo si la vida se esta drenando. Mediante inputs externos se checa
    si la vida se drena o no y continua el drenado según esto. Utiliza decimales del 0 al 1 donde 1 representa el 100%. Esto es el formato default.
*/

public class HealthBar : MonoBehaviour
{
    [SerializeField]float health = 1.0f;
    [SerializeField]float healthLossPerTick = 0.1f;
    public Slider slider; // Sirve para añadir una referencia a la propiedad de slider desde el inspector
    public GameObject textContainer; // Variable temporal para probar la lógica

    public string deathSceneName;

    bool healthDecreasing = false;

    private void Start() {
        textContainer.SetActive(false);
        slider.value = health; // Se desactiva el texto y se ajusta el slider a la vida
    }

    public void damageDrain(){
        healthDecreasing = true;
    }

    public void repairDrain(){
        healthDecreasing = false;
    } // Los dos métodos button pressed se conectan a los botones de la UI temporal pero la variable se ajustará con los tasks externos

    private void Update() {
        if(healthDecreasing){
            health -= healthLossPerTick * Time.deltaTime; // Se baja la vida segun la perdida por tick y se ajusta con deltaTime
            if (health < 0){
                healthDepleted(); // Si la vida se acaba se corre healthDepleted()
                health = 0.0f;
            }
            slider.value = health; // Se actualiza el slider
        }
    }

    public void healthDepleted(){
        //textContainer.SetActive(true); // Actualmente activa el texto de fin de juego, pero se reemplazará con la lógica ya que sea implementada
        SceneManager.LoadScene(deathSceneName);
    }

    /*
    // Funcion para update de vida version 1
    public void UpdateHealth(float _healthUpdateValue){ 
        // UpdateHealth toma como parametro un número positivo o negativo para actualizar la vida en la UI
        health += _healthUpdateValue;

        if(health > 1) health = 1.0f;
        else if (health < 0) health = 0.0f;
        // Estas dos lineas solo existen para evitar que la vida sobrepase los limites, pero en teoria no habría minijuego de heal si la vida esta llena 
        // y se acabaría el juego si la vida baja de 0

        slider.value = health;
    } 
    */
}
