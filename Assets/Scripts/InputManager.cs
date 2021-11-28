using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public GameObject[] effectedButtons;
    public GameObject locked;
    public int someIndex;
    public bool isPlayer;
    public int int_layer;
    AudioSource buttonSelectSound;
    // Start is called before the first frame update
    void Start()
    {
        int_layer = 0;
        if (GameObject.Find("Player"))
            isPlayer = true;
        else
            isPlayer = false;
        someIndex = 0;
        if (!isPlayer)
            DisplayHighlight();
        buttonSelectSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            GameObject.Find("ButtonManager").GetComponent<ButtonManager>().OpenPauseMenu();

        if (!isPlayer)
        {
            if (IsGood())
            {
                if (Input.GetKeyDown("up") || Input.GetKeyDown("w") || Input.GetKeyDown("a") || Input.GetKeyDown("left"))
                    SelectButton(-1);
                else if (Input.GetKeyDown("down") || Input.GetKeyDown("s") || Input.GetKeyDown("d")|| Input.GetKeyDown("right"))
                    SelectButton(1);
            }
            if (Input.GetKeyDown("space"))
            {
                if (GameObject.Find("MandatoryQuestion")&& GameObject.Find("MandatoryQuestion").transform.GetChild(0).gameObject.activeSelf)
                {
                    GameObject.Find("MandatoryQuestion").GetComponent<MQController>().AnswerCorrect();
                }
                else if (GameObject.Find("Hint")&&GameObject.Find("Hint").transform.GetChild(0).gameObject.activeSelf)
                {
                    if (GameObject.Find("Hint").GetComponent<HintController>().answered)
                    {
                        GameObject.Find("Hint").GetComponent<HintController>().CloseHint();
                    }
                    else
                    {

                        GameObject.Find("Hint").GetComponent<HintController>().AnswerCorrect();
                    }
                    someIndex = 0;
                    DisplayHighlight();
                }
                else
                {
                    PressButton();
                }

            }
        }
    }
    private void SelectButton(int direction)
    {

        ChangeButtonEffected(false);
        someIndex = someIndex + direction;
        if (someIndex >= effectedButtons.Length)
        {
            someIndex = 0;
        }
        else if (someIndex < 0)
        {
            someIndex = effectedButtons.Length - 1;
        }
        if (effectedButtons[someIndex].gameObject.layer != int_layer)
        {
            SelectButton(direction);
        }
        ChangeButtonEffected(true);
        buttonSelectSound.Play();
    }
    private void ChangeButtonEffected(bool open)
    {
        effectedButtons[someIndex].transform.GetChild(0).gameObject.GetComponent<ButtonEffect>().SetSelected(open);
    }
    private void PressButton()
    {
        effectedButtons[someIndex].transform.GetChild(1).gameObject.GetComponent<Button>().onClick.Invoke();
        effectedButtons[someIndex].transform.GetChild(0).gameObject.GetComponent<ButtonEffect>().SwitchLock();

        if (effectedButtons[someIndex].transform.GetChild(0).gameObject.GetComponent<ButtonEffect>().isLocked)
        {
            GameObject g = locked;
            locked = effectedButtons[someIndex];
            if ((locked.layer == 6 || locked.layer == 7) && locked.name != "Confirm")
            {
                if (int_layer == 7)
                {
                    int_layer = 6;
                    Image image = effectedButtons[someIndex].transform.GetChild(1).GetChild(0).GetChild(0).gameObject.GetComponent<Image>();
                    if (g.layer == 6)
                    {
                        g.transform.GetChild(1).GetChild(1).GetComponent<Image>().sprite = image.sprite;
                    }
                    UnlockLayer();
                    DisplayHighlight();
                }
                else
                {
                    int_layer = 7;
                    UnlockLayer();
                    DisplayHighlight();
                }
            }
        }
        else
        {
            if (locked.layer == 6 || locked.layer == 7)
            {
                if (int_layer == 7)
                {
                    int_layer = 6;
                    DisplayHighlight();
                }
                else
                {
                    int_layer = 7;
                }
            }
            locked = null;
        }
        
    }
    public void SwitchIsPlayer(bool b)
    {
        isPlayer = b;
        GameObject.Find("Player").GetComponent<PlayerController>().ToggleMovement();
        if (isPlayer) { int_layer = 0; }
        if (!isPlayer) { int_layer = 6; }
    }
    public void DisplayHighlight()
    {
        effectedButtons = GameObject.FindGameObjectsWithTag("EffectedButton");
        if (IsGood())
        {
            if (effectedButtons[someIndex].gameObject.layer != int_layer)
            {
                SelectButton(1);
            }
            else
            {
                ChangeButtonEffected(true);
            }
        }
    }

    public bool IsGood()
    {
        foreach (GameObject g in effectedButtons)
        {
            if (g.layer == int_layer)
            {
                return true;
            }
        }
        return false;
    }

    public void UnlockLayer()
    {
        foreach (GameObject g in effectedButtons)
        {
            if (g.layer == int_layer)
            {
                g.transform.GetChild(0).gameObject.GetComponent<ButtonEffect>().SetLocked(false);
            }
        }
    }

    public string GetButtonName() {
        return effectedButtons[someIndex].name;
    }
}
