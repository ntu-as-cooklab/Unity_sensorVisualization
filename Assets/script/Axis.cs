using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axis : MonoBehaviour {

    private LineRenderer lineRenderer;
    private int range = 100;  //cm
    private int interval = 1;  //cm
    private float width = 0.1F;
    public string plane;

	// Use this for initialization
	void Start () {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.useWorldSpace = enabled;
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;
        lineRenderer.material.color = Color.gray;
        lineRenderer.material.color = Color.gray;
        lineRenderer.positionCount = (range / interval+1) * 4;

        Vector3 p;
        int index = 0;
        int dir = 1;
        float[] axis = new float[3];
        for (int i = 0; i < (range / interval + 1); i++)
        {
            axis = Choose(plane,dir,i);
            p = new Vector3(axis[0], axis[1], axis[2]);
            lineRenderer.SetPosition(index++, p);

            dir *= -1;

            axis = Choose(plane, dir, i);
            p = new Vector3(axis[0], axis[1], axis[2]);
            lineRenderer.SetPosition(index++, p);
        }
        for (int i = (range / interval);i>=0; i--)
        {
            axis = Choose2(plane, dir, i);
            p = new Vector3(axis[0], axis[1], axis[2]);
            lineRenderer.SetPosition(index++, p);

            dir *= -1;

            axis = Choose2(plane, dir, i);
            p = new Vector3(axis[0], axis[1], axis[2]);
            lineRenderer.SetPosition(index++, p);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    float[] Choose(string plane,int dir,int i) {
        float x = 0, y = 0, z = 0;
        if (plane == "xy")
        {
            x = dir * range / 2;
            y = range / 2 - interval * i;
            z = 0;
        }
        else if (plane == "xz")
        {
            x = dir * range / 2;
            y = 0;
            z = range / 2 - interval * i;
        }
        else if (plane == "yz")
        {
            x = 0;
            y = dir * range / 2;
            z = range / 2 - interval * i;
        }
        float[] t = new float[] { x, y, z };
        return t;
    }
    float[] Choose2(string plane, int dir, int i)
    {
        float x = 0, y = 0, z = 0;
        if (plane == "xy")
        {
            x = range / 2 - interval * i;
            y = dir* range / 2;
            z = 0;
        }
        else if (plane == "xz")
        {
            x = range / 2 - interval * i;
            y = 0;
            z = dir* range / 2;
        }
        else if (plane == "yz")
        {
            x = 0;
            y = range / 2 - interval * i;
            z = dir* range / 2;
        }
        float[] t = new float[] { x, y, z };
        return t;
    }
}
    