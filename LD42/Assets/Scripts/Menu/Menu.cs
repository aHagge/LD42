﻿using System.Collections;
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

    public void quit()
    { }
    public void Startgame()
    {
        SceneManager.LoadScene("Main");
    }
}
