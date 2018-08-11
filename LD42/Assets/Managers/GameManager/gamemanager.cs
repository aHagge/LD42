using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gamemanager : MonoBehaviour {

    public static gamemanager instance;

    public TextMeshProUGUI timetext;

    public static bool turreton1, turreton2, turreton3, turreton4;

    public GameObject turret1, turret2, turret3, turret4;


    public static int bulletpenetration = 1;
    public static float bulletdmg = 30;
    public static float turretspeed;
    public static float bulletspeed;

    public static int day;

    private int minutes;
    private int hours;

    private void Start()
    {
        StartCoroutine(time());
        day++;
    }

    IEnumerator time()
    {
        yield return new WaitForSeconds(1);
        minutes++;
        if(minutes >= 60)
        {
            minutes = 0;
            hours++;
            if(hours >= 3)
            {
                print("stop");
            }
        }
        StartCoroutine(time());
    }
    private void Update()
    {      
        timetext.text = ("2018/07/" + day.ToString("D2") + "/" + hours.ToString("D2") + "/" + minutes.ToString("D2"));
        //if they are on
        if(turreton1)
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
