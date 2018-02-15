using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axis_2 : MonoBehaviour {
    public LineRenderer lineRenderer;
    public char axis;
    public float range = 100;
    public float width = 0.1F;
	// Use this for initialization
	void Start () {
        lineRenderer = this.gameObject.AddComponent<LineRenderer>();
        lineRenderer.useWorldSpace = enabled;
        lineRenderer.material.color = Color.gray;
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;
        Vector3[] pos = Choose(axis);
        lineRenderer.SetPosition(0, pos[0]);
        lineRenderer.SetPosition(1, pos[1]);
    }

    // Update is called once per frame
    void Update () {
		
	}
    Vector3[] Choose(char axis) {
        if (axis == 'x')
            return new Vector3[] { new Vector3(range, 0, 0), new Vector3(-range, 0, 0) };
        else if (axis == 'y')
            return new Vector3[] { new Vector3(0, range, 0), new Vector3(0, -range, 0) };
        else if (axis == 'z')
            return new Vector3[] { new Vector3(0, 0, range), new Vector3(0, 0, -range) };
        return null;
    }
}
