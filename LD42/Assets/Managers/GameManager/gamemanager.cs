using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour {

    public static gamemanager instance;

    public TextMeshProUGUI timetext;

    public static bool turreton1, turreton2, turreton3, turreton4;

    public GameObject turret1, turret2, turret3, turret4;

    private int scene;

    public static int bulletpenetration = 1;
    public static float bulletdmg = 30;
    public static float turretspeed = 1.5f;
    public static float bulletspeed = 10;

    public static int day;

    public static int alvl, blvl, clvl, dlvl;
    private int minutes;
    private int hours;

    public static int money;

    public static int simplezombiekilled;
    public static int babyzombiekilled;
    public static int giantzombiekilled;

    public TextMeshProUGUI moneytext;
    public TextMeshProUGUI enddaytext;

    public GameObject wavemanager;

    public string texta;
    public string currenttext;

    public float delay;


    public static int pencost = 1600, dmgcost = 200, turretspeedcost = 250, bullespeedcost = 150;
    private void Start()
    {
        scene = 2;
        day++;
        StartCoroutine(time());
        simplezombiekilled = 0;
        babyzombiekilled = 0;
        giantzombiekilled = 0;
}



    public void startday()
    {
        simplezombiekilled = 0;
        babyzombiekilled = 0;
        giantzombiekilled = 0;
        a = 0;
        b = 0;
        c = 0;
        hours = 9;
        minutes = 0;
        StartCoroutine(starti());      
    }
    
    IEnumerator starti()
    {
        
        if (wavemanager != null)
        {
            wavemanager.GetComponent<Wavemanager>().startwave();
            yield return new WaitForFixedUpdate();
            scene = 0;
        }
        else
        {
            yield return new WaitForSeconds(1);
            StartCoroutine(starti());            
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Zombie" || col.gameObject.tag == "Zombie2" || col.gameObject.tag == "Zombie3")
        {
            YourFired();
        }


    }

    public void YourFired()
    {
        scene = 2;
        SceneManager.LoadScene("Fired");
    }

    IEnumerator time()
    {
        yield return new WaitForSeconds(0.35f);
        minutes++;
        if (minutes >= 60)
        {
            minutes = 0;
            hours++;
        }

        StartCoroutine(time());
    }


    private void FixedUpdate()
    {

        if(wavemanager == null && SceneManager.GetActiveScene().buildIndex == 4)
        {
            wavemanager = GameObject.Find("Wavemanager");
        }
        if(timetext == null && scene == 0)
        {
            timetext = IKnow.timetext.GetComponent<TextMeshProUGUI>();
        }
        if (enddaytext == null && SceneManager.GetActiveScene().buildIndex == 3 && IKnow.endtext != null)
        {
            enddaytext = IKnow.endtext.GetComponent<TextMeshProUGUI>();
            moneytext = IKnow.moneytext.GetComponent<TextMeshProUGUI>();

        }
        if (hours == 14 && scene == 0)
        {
            Endday();
        }

        if(timetext != null)
        {
            timetext.text = ("2025/07/" + day.ToString("D2") + "/" + hours.ToString("D2") + ":" + minutes.ToString("D2"));
        }
        if (enddaytext != null)
        {
            moneytext.text = (money + "$");
            StartCoroutine(info());
            
        }
    }

    IEnumerator info()
    {
        texta = ("You killed:" + "  \r\n" + "  \r\n" + simplezombiekilled + " Common Zombies : " + a + "$" + "  \r\n" + "  \r\n" + babyzombiekilled + " Baby Zombies : " + b + "$" + "  \r\n" + "  \r\n" + giantzombiekilled + " Giant Zombies : " + c + "$" + "  \r\n" + "  \r\n" + "Total: " + (a+b+c) + "$");
        for (int i = 0; i < texta.Length + 1; i++)
        {
            currenttext = texta.Substring(0, i);
            enddaytext.text = currenttext;
            yield return new WaitForSeconds(delay);
        }
    }
    public int a, b, c;
    void Endday()
    {
        day++;
        SceneManager.LoadScene("Shop");
        scene = 1;
        a = simplezombiekilled * Random.Range(15, 35);
        b = babyzombiekilled * Random.Range(35, 50);
        c = giantzombiekilled * Random.Range(100, 150);
        money += (a + b + c);
    }

    private void Update()
    {      

        //if they are on
        if(turret3 != null)
        {
            if (turreton1)
            {
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
        } else
        {
            if(scene == 0)
            {
                turret1 = GameObject.Find("Turrets 1");
                turret2 = GameObject.Find("Turrets 2");
                turret3 = GameObject.Find("Turrets 3");
                turret4 = GameObject.Find("Turrets 4");
            }        
        }





        //if they are of
        if (turret3 != null)
        {
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


    public void restart()
    {
        pencost = 1600;
        dmgcost = 200;
        turretspeedcost = 250;
        bullespeedcost = 150;
        day = 1;
        money = 0;
        a = 0;
        b = 0;
        c = 0;
        alvl = 0;
        blvl = 0;
        clvl = 0;
        dlvl = 0;
        bulletpenetration = 1;
        bulletdmg = 30;
        turretspeed = 1.5f;
        bulletspeed = 10;
        SceneManager.LoadScene(0);
}
	
}
