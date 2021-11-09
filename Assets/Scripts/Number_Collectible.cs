using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Number_Collectible : MonoBehaviour
{
    public int number;
    // Start is called before the first frame update
    void Start()
    {
        string s = GetComponent<SpriteRenderer>().sprite.name;
        s = s.Substring(s.Length - 1);
        number = int.Parse(s);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.Find("Inventory").GetComponent<Inventory>().AddNumber(number);
            Destroy(this.gameObject);
        }
    }
}
