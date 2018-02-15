using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel_label : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void LabelUpdate(string time, string str) {
        gameObject.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = time;
        gameObject.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = str;
    }
}
