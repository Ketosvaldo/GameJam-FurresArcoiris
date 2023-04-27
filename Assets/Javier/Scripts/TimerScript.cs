using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
    TimerScript se utiliza para hacer la cuenta regresiva y escribirla en formato de tiempo en un text mesh pro, así como también para iniciar el proceso de victoria
    una vez el tiempo se haya terminado.
*/

public class TimerScript : MonoBehaviour
{
    public float time; // Se utiliza para contar el tiempo transcurrido
    bool timerOn = false; // Se utiliza para activar y desactivar el reloj
    public TMP_Text timerText; // Se utiliza para enlazar el texto y cambiarlo
    public GameObject winTextContainer; // Variable temporal para probar la victoria

    private void Start() {
        timerOn = true;
        winTextContainer.SetActive(false);
    }

    private void Update() {
        if(timerOn){
            if(time > 0){
                time -= Time.deltaTime; // Mientras aun quede tiempo y el reloj este encendido, se le resta al tiempo un segundo tomando en cuenta deltaTime
                UpdateTimerText(time); // Después se actualiza el texto
            }
            else{
                time = 0;
                timerOn = false;
                GameEnd(); // Si se acaba el tiempo, se desactiva el reloj y se inicia el final del juego
            }
        }
    }

    void UpdateTimerText(float currentTime){
        currentTime += 1; // Se suma 1 ya que se actualiza el texto despues de iniciado el sistema
        float min = Mathf.FloorToInt(currentTime / 60);
        float sec = Mathf.FloorToInt(currentTime % 60); // Se utiliza para dividir el tiempo en minutos y segundos para escribirse

        timerText.text = string.Format("{0:00} : {1:00}", min, sec); // Se escribe con formato de tiempo
    }

    public void GameEnd(){
        winTextContainer.SetActive(true); // Aquí se escribe la lógica del final del juego
    }

}
