using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEffect : MonoBehaviour
{
    public bool isSelected;
    public bool isLocked;
    public Color thisColor;
    public bool rightDirection = false;
    public float increment = 0.0017f;
    // Start is called before the first frame update

    void Awake()
    {
        thisColor = GetComponent<Image>().color;
        SetSelected(false);
        SetLocked(false);
        increment = 0.0051f;
    }


    // Update is called once per frame
    void Update()
    {
        if (!isLocked)
        {
            if (isSelected)
            {
                ChangeAlpha();
            }
        }
    }
    private void ChangeAlpha() {
        thisColor = GetComponent<Image>().color;
        if (thisColor.a <= 0f)
        {
            rightDirection = true;
        }
        else if (thisColor.a >= 1f)
        {
            rightDirection = false;
        }

        float newA;
        if (rightDirection)
            newA = thisColor.a + increment;
        else
            newA = thisColor.a - increment;
        GetComponent<Image>().color = new Color(thisColor.r, thisColor.g, thisColor.b, newA);
    }
    public void SetSelected(bool b)
    {
        isSelected = b;
        if (!isLocked)
        {
            if (isSelected)
                GetComponent<Image>().color = new Color(thisColor.r, thisColor.g, thisColor.b, 1f);
            else
                GetComponent<Image>().color = new Color(thisColor.r, thisColor.g, thisColor.b, 0f);
        }
    }
    public void SetLocked(bool b)
    {
        isLocked = b;
        if (isLocked)
            GetComponent<Image>().color = new Color(thisColor.r, thisColor.g, thisColor.b, 1f);
        else
            GetComponent<Image>().color = new Color(thisColor.r, thisColor.g, thisColor.b, 0f);
    }
    public void SwitchLock()
    {
        if (isLocked)
        {
            SetLocked(false);
        }
        else
        {
            SetLocked(true);
        }
    }
}
