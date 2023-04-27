using UnityEngine;
using UnityEngine.UI;

public class Reactor_Focos : MonoBehaviour
{
    public Image[] image;
    public bool[] isTurnedOn;
    public GameObject ReactorUI;

    GeneradorDeEventos eventGenerator;

    Reactor_Palanca lever;
    Reactor_Slider slider;
    private void Start()
    {
        eventGenerator = FindObjectOfType<GeneradorDeEventos>();
        lever = FindObjectOfType<Reactor_Palanca>();
        slider = FindObjectOfType<Reactor_Slider>();
    }
    public void TurnOn(int index)
    {
        image[index].color = Color.green;
        isTurnedOn[index] = true;

        CheckIfFinished();
    }

    public void TurnOff(int index)
    {
        image[index].color = Color.white;
        isTurnedOn[index] = false;
    }

    void CheckIfFinished()
    {
        if (isTurnedOn[0] && isTurnedOn[1])
        {
            GeneradorDeEventos.reactorIsActive = false;
            GeneradorDeEventos.reactorTimer = eventGenerator.reactorDelay;
            Movement.canMove = true;
            TurnOff(0);
            TurnOff(1);
            lever.slider.value = 0;
            slider.ResetSlider();
            ReactorUI.SetActive(false);
        }
    }
}
