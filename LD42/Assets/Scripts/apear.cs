using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class apear : MonoBehaviour {

    public float delay;
    public string killme;
    public string currenttext;

    private string hangme;
    private string shootme;


	// Use this for initialization

	void Start () {
        StartCoroutine(start());
        hangme = ("The zombie apocalypse is just getting started and the zombie forecast is expecting a rising amount of the next couple weeks on the east side of the country." + "  \r\n" + "  \r\n" + "John gets paid every day depending on how well he does his job. John will be instantly fired if he does his job bad." + "  \r\n" + "  \r\n" + "John plugs in the power cord with the color respective to the color of the cannon. The cannon will automatically start firing after one second until you unplug it." +"  \r\n" + "  \r\n" + "Simple enough.");
        shootme = ("Not only does he lack a power outlet, the power outlets are super sensitive and badly made so they will break when too much electricity go thru them. When they break John must press the key shown beside the broken outlet a bunch of times." + "  \r\n" + "  \r\n" + "Now you are John." + "  \r\n" + "Good Luck." + "  \r\n" + "And dont get fired." + "  \r\n" + "Your shift ends at 14:00");
        killme = ("This is John. " + "  \r\n" + "John has just got a job as a Security manager at one of those rich person houses. Unfortunately for him, it's a zombie apocalypse at the moment, so he got a lot to do. " + "  \r\n" + "  \r\n" + "They used to have three canons but now they upgraded to four weirdly they forgot to upgrade the power outlets so there are one too few. He is running out of space to put the power cords." + "  \r\n" + "  \r\n" + hangme + "  \r\n" + "  \r\n" + shootme);
    }

    // Update is called once per frame
    public void starta()
    {
        SceneManager.LoadScene("Day");
        FindObjectOfType<AudioManager>().Play("Click");
    }

    IEnumerator start()
    {
        for (int i = 0; i < killme.Length + 1; i++)
        {
            currenttext = killme.Substring(0, i);
            gameObject.GetComponent<TextMeshProUGUI>().text = currenttext;
            yield return new WaitForSeconds(delay);
        }
        FindObjectOfType<AudioManager>().Stop("Typing");
    }
}
