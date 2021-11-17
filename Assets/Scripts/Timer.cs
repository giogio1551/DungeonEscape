using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    public AudioClip healClip;
    public AudioClip hurtClip;
    AudioSource audioSrc;
    [SerializeField] private float time;
    private Text countdowntime;

    public static Timer instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
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

    public void Penalty(float penalty)
    {
        time -= penalty;
        audioSrc.clip = hurtClip;
        StartCoroutine(WaitAndColorBack(1.0f,Color.red));
    }
    IEnumerator WaitAndColorBack(float waitTime,Color c)
    {
        audioSrc.Play();
        countdowntime.color = c;
        yield return new WaitForSeconds(waitTime);
        countdowntime.color = Color.white;
        audioSrc.Stop();
    }
    public void Reward(float penalty)
    {

        time -= penalty;
        audioSrc.clip = healClip;
        StartCoroutine(WaitAndColorBack(1.0f,Color.green));
    }
}