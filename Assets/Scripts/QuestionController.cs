using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuestionController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AnswerCorrect()
    {
        string s1 = transform.GetChild(0).GetChild(3).GetChild(1).GetChild(1).GetComponent<Image>().sprite.name;
        string s2 = transform.GetChild(0).GetChild(4).GetChild(1).GetChild(1).GetComponent<Image>().sprite.name;
        string s3 = transform.GetChild(0).GetChild(5).GetChild(1).GetChild(1).GetComponent<Image>().sprite.name;
        s1 = s1.Substring(s1.Length - 1);
        s2 = s2.Substring(s2.Length - 1);
        s3 = s3.Substring(s3.Length - 1);
        if (s1 + s2 + s3 == "531")
        {
            GameObject.Find("ButtonManager").GetComponent<ButtonManager>().CloseQuestion();
            Destroy(GameObject.Find("Guardian"));
            GameObject.Find("Inventory").GetComponent<Inventory>().RemoveNumber(5);
            GameObject.Find("Inventory").GetComponent<Inventory>().RemoveNumber(3);
            GameObject.Find("Inventory").GetComponent<Inventory>().RemoveNumber(1);
            //GameObject.Find("Inventory").GetComponent<Inventory>().RemoveOperator(Operators.Minus);
        }

    }
}


