using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class IKnow : MonoBehaviour {


    public static GameObject timetext;

    public GameObject timetext2;

    public static GameObject endtext;
    public GameObject endtext2;

    public static GameObject moneytext;
    public GameObject moneytext2;

    public GameObject wavemanager;
    public static GameObject wavemanager2;

    public GameObject info;

    public GameObject playbutton;

    // Use this for initialization
    void Start () {
        if(playbutton != null)
        {
            playbutton.SetActive(false);
        }
     
    }
	
	// Update is called once per frame
	void Update () {
        if (timetext2 != null)
        {
            timetext = timetext2;
        }
        if (endtext2 != null)
        {
            endtext = endtext2;
        }
        if (moneytext2 != null)
        {
            moneytext = moneytext2;
        }
        if (wavemanager2 != null)
        {
            wavemanager = wavemanager2;
        }
    }


    public void close()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        info.SetActive(false);
        playbutton.SetActive(true);
    }

    public void nextday()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene("Day");
    }

    public void restart()
    {
        GameObject.Find("GameManager").GetComponent<gamemanager>().restart();
    }
}
