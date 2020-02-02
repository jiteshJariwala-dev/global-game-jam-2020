using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Restart()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        Application.LoadLevel(scene);
    }

    public void nextLevel()
    {
        Application.LoadLevel(2);
    }

    public void mainMenu()
    {
        Application.LoadLevel(0);
    }
}
