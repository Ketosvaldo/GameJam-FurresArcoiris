using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        Invoke("changeScene", 7);
    }

    void changeScene(){
        SceneManager.LoadScene("Menu");
    }
}
