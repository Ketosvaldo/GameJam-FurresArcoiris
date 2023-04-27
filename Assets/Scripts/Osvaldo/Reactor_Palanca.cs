using UnityEngine;
using UnityEngine.UI;

public class Reactor_Palanca : MonoBehaviour
{
    //Variable est�tica para reiniciar palanca sin tener que realizar una declaraci�n desde otro c�digo
    public static bool startReset;

    //Variables Privadas
    [SerializeField]
    float leverForce;       //Fuerza de decremento de la palanca
    [SerializeField]
    float astronautForce;   //Fuerza del astronauta para mover la palanca
    public Slider slider;          //Variable para declarar el Slider en cuesti�n
    public bool stopReduce;        //Booleano para saber cuando detener el slider

    private void Start()
    {
        //Le damos valores a cada variable
        slider = GetComponent<Slider>();
        stopReduce = false;
        startReset = false;
    }

    void Update()
    {
        //Si el slider no se est� reiniciando entonces...
        if (!startReset)
        {
            //Reduce el slider 
            DecrementSlider(stopReduce);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                IncrementSlider();
            }
            if (slider.value >= 1)
                stopReduce = true;
        }
        else
        {
            ResetSlider();
        }
    }

    void DecrementSlider(bool stopOperation)
    {
        if (!stopOperation)
            slider.value -= leverForce * Time.deltaTime;
    }

    void IncrementSlider()
    {
        slider.value += astronautForce * Time.deltaTime;
    }

    void ResetSlider()
    {
        slider.value -= leverForce * 2 * Time.deltaTime;
        if (slider.value <= 0)
        {
            startReset = false;
            stopReduce = false;
        }
    }
}
