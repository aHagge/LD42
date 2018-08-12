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
    public static float turretspeed;
    public static float bulletspeed;

    public static int day;

    private int minutes;
    private int hours;



    public static int simplezombiekilled;
    public static int babyzombiekilled;
    public static int giantzombiekilled;

    public TextMeshProUGUI enddaytext;
    private void Start()
    {
        startday();
        print("start day");
        StartCoroutine(time());
        simplezombiekilled = 0;
        babyzombiekilled = 0;
        giantzombiekilled = 0;
}

    public void startday()
    {
        scene = 0;
        hours = 9;
        minutes = 0;

    }



    IEnumerator time()
    {
        yield return new WaitForSeconds(0.1f);
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
        if(timetext == null && scene == 0)
        {
            print(scene);
            timetext = IKnow.timetext.GetComponent<TextMeshProUGUI>();
        }
        if (enddaytext == null && scene == 1)
        {
            enddaytext = IKnow.endtext.GetComponent<TextMeshProUGUI>();
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
            int a = simplezombiekilled * Random.Range(50,70);
            int b = babyzombiekilled * Random.Range(100, 120);
            int c = giantzombiekilled * Random.Range(400, 500);
            enddaytext.text = (simplezombiekilled + "Common Zombies Killed : " + a + "$" + "  \r\n" + "hello");
        }
    }

    void Endday()
    {
        day++;
        SceneManager.LoadScene("Shop");
        scene = 1;
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
	
}
