using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Button : MonoBehaviour {

    public SensorCreater sensorCreater;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnStratBtn() {
        BoxMove.Going = true;
    }

    public void OnPauseBtn() {
        BoxMove.Going = false;
    }

    public static void Pause() {
        BoxMove.Going = false;
    }

    public void OnRetryBtn() {
        BoxMove.Going = false;
        BoxMove.NowDataIte = 0;
        BoxMove.NowSensor = 0;
        BoxMove.Retrying = true;
    }

    public void OnSceneChangeBtn() {
        string SensorChosen;
        SensorChosen = gameObject.GetComponentInChildren<UnityEngine.UI.Text>().text;
        OnRetryBtn();
        BoxMove.Retrying = false;
        BoxMove.SensorNum = 1;
        GameObject g = sensorCreater.CopyBox(SensorChosen);
        g.tag = "passing";
        DontDestroyOnLoad(g);
        SceneManager.LoadScene("single_sensor");
    }

    public void OnBackToTreeBtn() {
        OnRetryBtn();
        Destroy(GameObject.FindGameObjectWithTag("passing"));
        SceneManager.LoadScene("tree");
    }
}
