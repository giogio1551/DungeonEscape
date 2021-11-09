using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Vector2 itemPosition;
    public GameObject minus;
    public GameObject plus;
    private List<Operators> operatorList = new List<Operators>();
    private List<int> numberList = new List<int>();
    private List<GameObject> operatorDisplay = new List<GameObject>();

    public Vector2 displacement;
    public float displacementDifference;



    public void AddOperator(Operators op)
    {
        operatorList.Add(op);
        switch (op)
        {
            case Operators.Minus:
                operatorDisplay.Add(Instantiate(minus, new Vector3(displacement.x, displacement.y, 0), Quaternion.identity, this.gameObject.transform));
                displacement.y -= displacementDifference;
                break;
            case Operators.Plus:
                operatorDisplay.Add(Instantiate(plus, new Vector3(displacement.x, displacement.y, 0), Quaternion.identity, this.gameObject.transform));
                displacement.y -= displacementDifference;
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
