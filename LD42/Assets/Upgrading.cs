using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Upgrading : MonoBehaviour {

    public int cost;

    public bool penetration, turretspeed, bulletspeed, dmg;

    public int level;

    public TextMeshProUGUI costtext;
    public TextMeshProUGUI leveltext;

    public GameObject[] leveldots;

    private int i;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void upgrade()
    {
        if(cost <= gamemanager.money && level < 10)
        {
            if(penetration)
            {
                gamemanager.bulletpenetration++;
                gamemanager.money -= cost;
                level++;
                leveldots[i].SetActive(true);
                i++;
                cost += 70;
            }
        }
    }
}
