using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour {

    public GameObject credits, normal;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void credit()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        normal.SetActive(false);
        credits.SetActive(true);
    }
    public void normala()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        normal.SetActive(true);
        credits.SetActive(false);
    }
    public void quit()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        Application.Quit();
    }
    public void Startgame()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene("Story");
    }

    public int width;
    public int height;
    public void setwith(int newwith)
    {
        width = newwith;
    }
    public void setheight(int newheight)
    {
        height = newheight;
    }

    public void Setres()
    {
        Screen.SetResolution(width, height, false);
    }
}
