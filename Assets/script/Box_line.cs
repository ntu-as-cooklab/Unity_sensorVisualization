using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_line : MonoBehaviour {

    private LineRenderer lineRenderer;
    private static int index = 0;
    private static int sensorNum; // be set in SensorCreater (line 41)
    private static int nowSensor = 0;
    public static float width = 0.2F;

    public static int NowSensor
    {
        get
        {
            return nowSensor;
        }

        set
        {
            if (nowSensor <= SensorNum)
            {
                nowSensor = value;
            }
            else
            {
                print(nowSensor);
                print("Box_line sensorNum error");
            }
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

    public static int Index
    {
        get
        {
            return index;
        }

        set
        {
            index = value;
        }
    }

    // Use this for initialization
    void Start () {
        //lineRender Initial
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.SetPositions(new Vector3[] { new Vector3(0, 0, 0) });
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;
        lineRenderer.material.color = Color.blue;
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    public void DrawLine() {
        lineRenderer.positionCount = Index + 1;
        lineRenderer.SetPosition(Index, this.transform.position);
        NowSensor++;
        if(NowSensor == SensorNum)
        {
            Index++;
            NowSensor = 0;
        }
    }
    public void OnRetryBtn()
    {
        lineRenderer.SetPositions(new Vector3[] { new Vector3(0, 0, 0) });
        Index = 0;
    }
}
