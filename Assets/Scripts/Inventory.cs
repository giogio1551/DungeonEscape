using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Vector2 itemPosition;
    public GameObject minus;
    public GameObject plus;
    private List<Operators> operatorList;
    private List<int> numberList;

    // Start is called before the first frame update
    public void UpdateInventory(List<Operators> opList = null, List<int> numList = null)
    {
        //Debug.Log(opList);
        if (opList != null)
        {
            operatorList = opList;
        }
        if (numList != null)
        {
            numberList = numList;
        }

        DisplayInventory();
    }

    public void DisplayInventory()
    {
        float displacement = 0;
        foreach (var op in operatorList)
        {
            Debug.Log(op);
            switch (op)
            {
                case Operators.Minus:
                    Instantiate(minus, new Vector3(itemPosition.x, itemPosition.y + displacement, 0), Quaternion.identity);
                    break;
            }
        }
    }
}
