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
    public void CloseQuestion() 
    {
        GameObject.Find("Question").transform.GetChild(0).gameObject.SetActive(false);
        GameObject.Find("InputManager").GetComponent<InputManager>().SwitchIsPlayer(true);
    }
    public void CloseHint()
    {
        GameObject.Find("Hint").GetComponent<HintController>().CloseHint();
    }
    public void OpenPauseMenu()
    {
        if (GameObject.Find("Question"))
            CloseQuestion();
        GameObject.Find("PauseMenu").transform.GetChild(0).gameObject.SetActive(true);
        GameObject.Find("InputManager").GetComponent<InputManager>().SwitchIsPlayer(false);
        GameObject.Find("InputManager").GetComponent<InputManager>().DisplayHighlight();
    }
    public void ClosePauseMenu()
    {
        GameObject.Find("PauseMenu").transform.GetChild(0).gameObject.SetActive(false);
        GameObject.Find("InputManager").GetComponent<InputManager>().SwitchIsPlayer(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void OpenInventory()
    {
        GameObject.Find("InputManager").GetComponent<InputManager>().DisplayHighlight();
    }

    public void AnswerQuestion()
    {
        GameObject.Find("Question").GetComponent<QuestionController>().AnswerCorrect();
    }
    public void AnswerHint()
    {
        GameObject.Find("Hint").GetComponent<HintController>().AnswerCorrect();
    }
}
