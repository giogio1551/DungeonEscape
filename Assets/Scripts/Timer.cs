using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{

    [SerializeField] private float time;
    private Text countdowntime;

    // Start is called before the first frame update
    void Start()
    {
        countdowntime = gameObject.GetComponent<Text>();
        countdowntime.text = time.ToString("F0");
        

    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            countdowntime.text = time.ToString("F0");
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}