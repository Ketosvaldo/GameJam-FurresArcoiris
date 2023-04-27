using UnityEngine;
using UnityEngine.UI;

public class Reactor_Focos : MonoBehaviour
{
    public Image[] image;
    public bool[] isTurnedOn;
    public bool exit;
    public void TurnOn(int index)
    {
        image[index].color = Color.green;
        isTurnedOn[index] = true;

        if (isTurnedOn[0] && isTurnedOn[1])
            gameObject.SetActive(false);
    }

    public void TurnOff(int index)
    {
        image[index].color = Color.white;
        isTurnedOn[index] = false;
    }
}
