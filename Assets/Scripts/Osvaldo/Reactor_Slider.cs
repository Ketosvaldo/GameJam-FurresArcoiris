using UnityEngine;
using UnityEngine.UI;

public class Reactor_Slider : MonoBehaviour
{
    [SerializeField]
    float resetSliderSpeed;
    bool startReset;
    Slider slider;

    Reactor_Focos lights;
    Reactor_Palanca lever;
    void Start()
    {
        slider = GetComponent<Slider>();
        startReset = false;
        lights = FindObjectOfType<Reactor_Focos>();
        lever = FindObjectOfType<Reactor_Palanca>();
    }

    private void Update()
    {
        if(startReset && slider.value > 0)
            slider.value -= resetSliderSpeed * Time.deltaTime;
        else
        {
            startReset = false;
            slider.interactable = true;
        }   
    }

    public void CheckValue()
    {
        if (slider.value == 1 && lever.slider.value == 1)
        {
            Reactor_Palanca.startReset = true;
            startReset = true;
            slider.interactable = false;
            if (!lights.isTurnedOn[0])
                lights.TurnOn(0);
            else if (!lights.isTurnedOn[1])
                lights.TurnOn(1);
        }
        else if(slider.value == 1 && lever.slider.value != 1 && !startReset)
        {
            startReset = true;
            slider.interactable = false;
            if (lights.isTurnedOn[1])
                lights.TurnOff(1);
            else if (lights.isTurnedOn[0])
                lights.TurnOff(0);
        }
    }
}