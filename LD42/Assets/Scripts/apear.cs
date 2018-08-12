using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class apear : MonoBehaviour {

    public float delay;
    public string killme;
    public string currenttext;


	// Use this for initialization

	void Start () {
        StartCoroutine(start());
    }

    // Update is called once per frame
    public void starta()
    {
        SceneManager.LoadScene("Main");
    }

    IEnumerator start()
    {
        for (int i = 0; i < killme.Length + 1; i++)
        {
            currenttext = killme.Substring(0, i);
            gameObject.GetComponent<TextMeshProUGUI>().text = currenttext;
            yield return new WaitForSeconds(delay);
        }
    }
}
