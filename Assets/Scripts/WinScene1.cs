using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScene1 : MonoBehaviour
{
    public void Start()
    {
        Invoke("changeScene", 7);
    }

    void changeScene(){
        SceneManager.LoadScene("Level2");
    }
}
