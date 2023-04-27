using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    HealthBar toma un componente de slider y cambia el estado de progreso de la barra con el metodo UpdateHealth. El método se llama externamente desde objetos
    que disminuyan o aumenten la vida de la nave (escudos de la nave). Utiliza decimales del 0 al 1 donde 1 representa el 100%. Esto es el formato default.
*/

public class HealthBar : MonoBehaviour
{
    [SerializeField]float health = 1.0f;
    public Slider slider; // Sirve para añadir una referencia a la propiedad de slider desde el inspector

    bool healthDecreasing;



    /*
    // Funcion para update de vida
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
