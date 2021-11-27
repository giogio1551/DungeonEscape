using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Number_Collectible : MonoBehaviour
{
    public int number;
    AudioSource pickupItem;
    // Start is called before the first frame update
    void Start()
    {
        string s = GetComponent<SpriteRenderer>().sprite.name;
        s = s.Substring(s.Length - 1);
        number = int.Parse(s);
        pickupItem = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerController.self.CollectNumber(number);
            Destroy(this.gameObject);
        }
    }
}
