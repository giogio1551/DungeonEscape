using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintController : MonoBehaviour
{
    public SageController sage = null;
    public GameObject sage_go = null;
    public bool answered = false;
    public Text words;
    public Text question;
    public Text choiceA;
    public Text choiceB;
    public Text choiceC;
    public Text choiceD;
    public List<GameObject> Buttons;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Display(GameObject s)
    {
        sage_go = s;
        sage = s.GetComponent<SageController>();
        question.text = sage.question;
        foreach (GameObject g in Buttons)
        {
            g.SetActive(true);
        }
        choiceA.text = sage.answers[0];
        choiceB.text = sage.answers[1];
        choiceC.text = sage.answers[2];
        choiceD.text = sage.answers[3];
    }
    public void AnswerCorrect()
    {
        answered = true;
        string name = GameObject.Find("InputManager").GetComponent<InputManager>().GetButtonName();
        name = name.Substring(name.Length - 1);
        int c = int.Parse(name) - 1;
        if (c == sage.correct_answer)
        {
            foreach (GameObject g in Buttons)
            {
                g.SetActive(false);
            }
            words.text = "Congradulation! You did it right!\nHere is the hint!\n"+ sage.hint;
            question.text = "";
            GameObject.Find("InputManager").GetComponent<InputManager>().int_layer = 6;
            GameObject.Find("InputManager").GetComponent<InputManager>().someIndex = 0;
            GameObject.Find("InputManager").GetComponent<InputManager>().DisplayHighlight();
        }
        else {
            CloseHint();
        }
    }
    public void CloseHint()
    {
        words.text = "i will leave you a hint if you can do my math problem right";
        foreach (GameObject g in Buttons)
        {
            g.transform.GetChild(0).gameObject.GetComponent<ButtonEffect>().SetSelected(false);
            g.transform.GetChild(0).gameObject.GetComponent<ButtonEffect>().SetLocked(false);
        }
        GameObject.Find("Hint").transform.GetChild(0).gameObject.SetActive(false);
        GameObject.Find("InputManager").GetComponent<InputManager>().SwitchIsPlayer(true);
        if (answered)
        {
            Destroy(sage_go);
        }

    }
}
