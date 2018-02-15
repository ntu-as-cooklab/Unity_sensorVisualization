using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BoxMove : MonoBehaviour {

    private Box_line box_Line;
    private Panel_label panel_Label;
    private List<float[]> data = new List<float[]>();  //store all txt in data[] in start
    private List<string[]> label = new List<string[]>();
    private Vector3 initialPos = new Vector3(0,0,0);
    private int TotalDataNum;
    private static int nowSensor = 0;
    private static int sensorNum;  // be set in SensorCreater (line 42)
    private static int nowDataIte = 0;
    private static int retryIte = 0;
    private static bool going = false;
    private static bool retrying = false;


    public static bool Retrying
    {
        get
        {
            return retrying;
        }
        set
        {
            retrying = value;
        }
    }

    public static bool Going
    {
        get
        {
            return going;
        }

        set
        {
            going = value;
        }
    }

    public static int NowSensor
    {
        get
        {
            return nowSensor;
        }

        set
        {
            nowSensor = value;
        }
    }

    public static int NowDataIte
    {
        get
        {
            return nowDataIte;
        }

        set
        {
            nowDataIte = value;
        }
    }

    public static int SensorNum
    {
        get
        {
            return sensorNum;
        }

        set
        {
            sensorNum = value;
        }
    }

    public Vector3 InitialPos
    {
        get
        {
            return initialPos;
        }

        set
        {
            initialPos = value;
        }
    }


    // Use this for initialization
    void Start () {
        //read file
        string data_raw;
        string[] data_lines;
        //string path = "txt\\" + this.gameObject.name + ".txt";
        string path = "txt\\" + this.gameObject.name + ".txt";
        try
        {
            data_raw = File.ReadAllText(path);
        }
        catch
        {
            print(gameObject.name + " find no file, already disabled");
            return;
        }
        data_lines = data_raw.Split('\n');
        TotalDataNum = data_lines.Length;

        //change string data into int 
        foreach (string i in data_lines) {
            string[] t = i.Split(',');
            float[] k = new float[] { float.Parse(t[0]), float.Parse(t[1]), float.Parse(t[2]), float.Parse(t[3]), float.Parse(t[4]), float.Parse(t[5]) };
            data.Add(k);
            string[] j = new string[] { t[6], t[7] };
            label.Add(j);
        }

        //initial position
        gameObject.transform.position = InitialPos;


        //initial Linrenderer
        try
        {
            box_Line = gameObject.GetComponent<Box_line>();
        }
        catch
        {
            print(gameObject.name + " BoxMove get Line error");
            box_Line = null;
        }

        //initial label
        try
        {
            panel_Label = GameObject.Find("Panel_label").GetComponent<Panel_label>();
        }
        catch
        {
            print("BoxMove FindLabel error");
        }

        print(SensorNum);

    }

    // Update is called once per frame
    void Update () {
        if (retrying == true) {
            if (box_Line != null)
            {
                box_Line.OnRetryBtn();
                Going = true;
            }
        }
        if (Going == true)
        {
            if (NowDataIte < TotalDataNum)
            {
                //label update 
                if (NowSensor == 0)
                {
                    if(panel_Label == null)
                    {
                        try
                        {
                            panel_Label = GameObject.Find("Panel_label").GetComponent<Panel_label>();
                        }
                        catch
                        {
                            print("BoxMove FindLabel error");
                        }
                    }
                    panel_Label.LabelUpdate(label[NowDataIte][0], label[NowDataIte][1]);
                }
                //move (and add initial pos)
                transform.position = new Vector3(data[NowDataIte][0] + InitialPos.x , data[NowDataIte][2] + InitialPos.y, data[NowDataIte][1] + InitialPos.z);
                transform.rotation = Quaternion.Euler(data[NowDataIte][3], data[NowDataIte][5], data[NowDataIte][4]);

                NowSensor++;

                if (NowSensor == SensorNum)
                {
                    NowDataIte++;
                    NowSensor = 0;
                }

                //draw line
                if (box_Line != null)
                {
                    box_Line.DrawLine();
                }
            }
            else
            {
                print("End");
                NowDataIte = 0;
                Going = false;
            }
            if (Retrying == true) {
                retryIte++;
                print(NowSensor + gameObject.name);
                if (retryIte == SensorNum)
                {
                    retryIte = 0;
                    Going = false;
                    Retrying = false;
                }
            }
        }
    }
}
