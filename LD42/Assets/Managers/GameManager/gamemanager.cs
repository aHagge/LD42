﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour {

    public static gamemanager instance;

    public static bool turreton1, turreton2, turreton3, turreton4;


    public GameObject turret1, turret2, turret3, turret4;

    private void Update()
    {
        //if they are on
        if(turreton1)
        {
            print("shoot");
            turret1.GetComponent<Turret>().shooting = true;
        }
        if (turreton2)
        {
            turret2.GetComponent<Turret>().shooting = true;
        }
        if (turreton3)
        {
            turret3.GetComponent<Turret>().shooting = true;
        }
        if (turreton4)
        {
            turret4.GetComponent<Turret>().shooting = true;
        }




        //if they are of
        if (!turreton1)
        {
            turret1.GetComponent<Turret>().shooting = false;
        }
        if (!turreton2)
        {
            turret2.GetComponent<Turret>().shooting = false;
        }
        if (!turreton3)
        {
            turret3.GetComponent<Turret>().shooting = false;
        }
        if (!turreton4)
        {
            turret4.GetComponent<Turret>().shooting = false;
        }
    }

    void Awake () {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
	
}
