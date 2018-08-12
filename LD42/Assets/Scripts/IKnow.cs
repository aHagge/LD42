using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKnow : MonoBehaviour {


    public static GameObject timetext;

    public GameObject timetext2;

    public static GameObject endtext;
    public GameObject endtext2;
    // Use this for initialization
    void Start () {
        if (timetext2 != null)
        {
            timetext = timetext2;
        }
        if (endtext2 != null)
        {
            endtext = endtext2;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
