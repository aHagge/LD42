using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Textapear : MonoBehaviour {

    public float delay;

    public string day;

    private string currenttext;
	// Use this for initialization
	void Start () {
        day = "Day " + gamemanager.day;

        StartCoroutine(show());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator show()
    {
        for (int i = 0; i < day.Length + 1; i++)
        {
            currenttext = day.Substring(0, i);
            gameObject.GetComponent<TextMeshProUGUI>().text = currenttext;
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(2);
        GameObject gm = GameObject.Find("GameManager");
        gm.GetComponent<gamemanager>().startday();
        SceneManager.LoadScene("Main");
    }
}
