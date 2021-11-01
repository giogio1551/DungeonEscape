using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenMainGameScene()
    {
        SceneManager.LoadScene("MainGameScene");
    }
    public void OpenControlScene()
    {
        SceneManager.LoadScene("ControlScene");
    }
    public void OpenMainMenuScene()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
