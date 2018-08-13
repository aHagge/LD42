using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Upgrading : MonoBehaviour {

    public bool penetration, turretspeed, bulletspeed, dmg;

    private int level;

    private int cost;
    public TextMeshProUGUI costtext;
    public TextMeshProUGUI leveltext;

    public GameObject[] leveldots;

    private int a;
	// Use this for initialization
	void Start () {
		foreach(GameObject a in leveldots)
        {
            a.SetActive(false);
        }

    }
	
	// Update is called once per frame
	void Update () {
        leveltext.text = level.ToString();
        costtext.text = cost.ToString();
        if(penetration)
        {
            level = gamemanager.alvl;
            cost = gamemanager.pencost;
        }
        if (bulletspeed)
        {
            level = gamemanager.blvl;
            cost = gamemanager.bullespeedcost;
        }
        if (dmg)
        {
            level = gamemanager.clvl;
            cost = gamemanager.dmgcost;
        }
        if (turretspeed)
        {
            level = gamemanager.dlvl;
            cost = gamemanager.turretspeedcost;
        }
        for (int i = 0; i < level; i++)
        {
            leveldots[i].SetActive(true);
        }
    }

    public void upgrade()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        if (cost <= gamemanager.money && level < 10)
        {
            if(penetration)
            {
                gamemanager.bulletpenetration++;
                gamemanager.money -= cost;
                gamemanager.alvl++;
                leveldots[a].SetActive(true);
                a++;
                gamemanager.pencost += 100;
            }
            if (dmg)
            {
                gamemanager.clvl++;
                gamemanager.bulletdmg += 10;
                gamemanager.money -= cost;
                leveldots[a].SetActive(true);
                a++;
                gamemanager.dmgcost += 70;
            }
            if (bulletspeed)
            {
                gamemanager.blvl++;
                gamemanager.bulletspeed += 1;
                gamemanager.money -= cost;
                leveldots[a].SetActive(true);
                a++;
                gamemanager.bullespeedcost += 50;
            }
            if (turretspeed)
            {
                gamemanager.dlvl++;
                gamemanager.turretspeed -= 0.1f;
                gamemanager.money -= cost;
                leveldots[a].SetActive(true);
                a++;
                gamemanager.turretspeedcost += 60;
            }
        }
    }
}
