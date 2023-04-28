using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{
    public GameObject PausaUI;
    public static bool isPause;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
            {
                Movement.canMove = true;
                Time.timeScale = 1;
                PausaUI.SetActive(false);
            }
            else
            {
                Movement.canMove= false;
                Time.timeScale = 0;
                PausaUI.SetActive(true);
            }
            isPause = !isPause;
        }
    }

    public void Resume()
    {
        isPause = false;
        Time.timeScale = 1;
        PausaUI.SetActive(false);
        Movement.canMove = true;
    }
}
