using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor;
using System.IO;

public class SensorCreater : MonoBehaviour {

    private string Path = "txt\\";
    public string FileName = "sensor_";
    public string InitialPos = "InitialPosition.txt";    //set the sensor's position on the tree
    public static int SensorNum;
    public GameObject BoxesCopyFrom;
    public GameObject BtnsCopyFrom;
    private List<GameObject> Boxes;
    private List<GameObject> ChooseBtns;
 

	// Use this for initialization
	void Start () {
        Boxes = new List<GameObject>();
        ChooseBtns = new List<GameObject>();
        BoxesCopyFrom = GameObject.Find("sensor_demo");
        BtnsCopyFrom = GameObject.Find("button_demo");
        string[] InitPos = File.ReadAllLines(Path + InitialPos);
        string filePath = Path + FileName;
        int index = 0;

        //if sensor_index exist, create a box for it
        while ( File.Exists(filePath + index.ToString() + ".txt") )
        {
            Boxes.Add(Instantiate(BoxesCopyFrom));
            Boxes[index].name = FileName + index.ToString();
            string[] p = InitPos[index].Split(',');
            Boxes[index].GetComponent<BoxMove>().InitialPos = new Vector3(float.Parse(p[0]), float.Parse(p[2]), float.Parse(p[1])); //y, z reverse

            ChooseBtns.Add(Instantiate(BtnsCopyFrom));
            ChooseBtns[index].name = FileName + index.ToString();
            ChooseBtns[index].transform.SetParent( GameObject.Find("Panel_Choose").transform);
            ChooseBtns[index].GetComponentInChildren<UnityEngine.UI.Text>().text = FileName + index.ToString(); ;
            index++;
        }
        SensorNum = index;
        Box_line.SensorNum = SensorNum;
        BoxMove.SensorNum = SensorNum;

        //disActive all the demo obj
        BoxesCopyFrom.SetActive(false);
        BtnsCopyFrom.SetActive(false);
        GameObject.Find("Panel_Choose").SetActive(false);

    }

    //used for Scene change (dontDestroyOnload)
    public GameObject CopyBox(string BoxName) {
        BoxMove.Going = false; BoxesCopyFrom.SetActive(true);
        GameObject g = Instantiate(BoxesCopyFrom);
        g.name = BoxName;
        return g;
    }
	
	// Update is called once per frame
//	void Update () {
		
//	}
}
