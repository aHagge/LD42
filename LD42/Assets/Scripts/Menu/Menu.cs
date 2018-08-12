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
        normal.SetActive(false);
        credits.SetActive(true);
    }
    public void normala()
    {
        normal.SetActive(true);
        credits.SetActive(false);
    }
    public void quit()
    {
        Application.Quit();
    }
    public void Startgame()
    {
        SceneManager.LoadScene("Story");
    }
}
