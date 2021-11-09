using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
    public Vector2 itemPosition;
    public GameObject minus;
    public GameObject plus;
    public List<GameObject> numbers;
    private List<Operators> operatorList = new List<Operators>();
    private List<int> numberList = new List<int>();
    public List<GameObject> operatorDisplay = new List<GameObject>();

    public Vector2 displacement;
    public Vector2 displacement_Origin;
    public float displacementDifference;

	private void Start()
	{
        displacement_Origin = new Vector2(displacement.x, displacement.y);
    }
	public void AddNumber(int n)
    {
        numberList.Add(n);
        operatorDisplay.Add(Instantiate(numbers[n], new Vector3(displacement.x, displacement.y, 0), Quaternion.identity, transform));
        DisplayStuffs();
        //displacement.y -= displacementDifference;
    }
    public void RemoveNumber(int n)
    {
        numberList.Remove(n);
        GameObject target = null;
        foreach (GameObject g in operatorDisplay)
        {
            String s = g.transform.GetChild(1).GetChild(0).GetChild(0).gameObject.GetComponent<Image>().sprite.name;
            s = s.Substring(s.Length - 1);
            int number = int.Parse(s);
            if (number == n)
            {
                target = g;
                break;
            }
        }
        if (target)
        {
            operatorDisplay.Remove(target);
            Destroy(target);
        }
        DisplayStuffs();
        //displacement.y -= displacementDifference;
    }
    public void DisplayStuffs()
    {
        for (int i = 0; i < operatorDisplay.Count; i++)
        {
            operatorDisplay[i].transform.position = new Vector3(displacement.x, displacement_Origin.y - displacementDifference*i, 0);
        }
    }
    public void AddOperator(Operators op)
    {
        operatorList.Add(op);
        switch (op)
        {
            case Operators.Minus:
                operatorDisplay.Add(Instantiate(minus, new Vector3(displacement.x, displacement.y, 0), Quaternion.identity, transform));
                DisplayStuffs();
                //displacement.y -= displacementDifference;
                break;
            case Operators.Plus:
                operatorDisplay.Add(Instantiate(plus, new Vector3(displacement.x, displacement.y, 0), Quaternion.identity, transform));
                DisplayStuffs();
                //displacement.y -= displacementDifference;
                break;
        }
    }

    public void RemoveOperator(Operators operatorType)
    {
        for(int i = 0; i < operatorList.Count; i++)
        {
            if(operatorList[i] == operatorType)
            {
                Vector3 displayPosition = operatorDisplay[i].transform.position;
                GameObject toBeDestroyed = operatorDisplay[i];
                operatorDisplay.Remove(toBeDestroyed);
                operatorList.Remove(operatorType);
                Destroy(toBeDestroyed);
                AdjustDisplay(displayPosition, i);
                displacement.y += displacementDifference;
                return;
            }
        }
        Debug.Log("Operator doesnt exist!");
    }

    private void AdjustDisplay(Vector3 initialPosition, int startIndex)
    {
        Vector3 pos = initialPosition;
        for(int i = startIndex; i < operatorList.Count; i++)
        {
            Vector3 temp = operatorDisplay[i].transform.position;
            operatorDisplay[i].transform.position = pos;
            pos = temp;
        }
    }
}
