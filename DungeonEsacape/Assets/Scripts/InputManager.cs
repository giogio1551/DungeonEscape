 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    private GameObject[] effectedButtons;
    public int someIndex;

    // Start is called before the first frame update
    void Start()
    {
        someIndex = 0;
        effectedButtons = GameObject.FindGameObjectsWithTag("EffectedButton");
        ChangeButtonEffected(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("up") || Input.GetKeyDown("w"))
            SelectButton(someIndex - 1);
        else if (Input.GetKeyDown("down") || Input.GetKeyDown("s"))
            SelectButton(someIndex + 1);
        if (Input.GetKeyDown("space"))
            PressButton();
    }
    private void SelectButton(int index) 
    {
	    ChangeButtonEffected(false);
        someIndex = index;
        if (someIndex >= effectedButtons.Length)
        {
            someIndex = 0;
        }
        else if (someIndex < 0)
        {
            someIndex = effectedButtons.Length-1;
        }
        ChangeButtonEffected(true);

    }
    private void ChangeButtonEffected(bool open)
    {
        effectedButtons[someIndex].transform.GetChild(0).gameObject.GetComponent<ButtonEffect>().SetSelected(open);
    }
    private void PressButton() {
        effectedButtons[someIndex].transform.GetChild(1).gameObject.GetComponent<Button>().onClick.Invoke();
    }

}
