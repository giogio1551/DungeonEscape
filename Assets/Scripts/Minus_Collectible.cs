using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minus_Collectible : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerController.self.CollectOperator(Operators.Plus);
            Destroy(this.gameObject);
        }
    }
}
