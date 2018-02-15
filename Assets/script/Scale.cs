using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour {
    public GameObject[] textObj;
    public GameObject CopyFrom;
    public char axis;
    public float range = 100;
    public int interval = 5;
	// Use this for initialization
	void Start () {
        textObj = new GameObject[(int)range];
        for(int i = 0; i < range/interval; i++)
        {
            textObj.SetValue(GameObject.Instantiate(CopyFrom), i);
            textObj[i].transform.parent = gameObject.transform;
            textObj[i].name =string.Format("{0}",  -range/2 + i * interval);
            Vector3 pos = Choose(axis, i);
            textObj[i].transform.position = pos;

            TextMesh text = textObj[i].GetComponent<TextMesh>();
            text.text = textObj[i].name;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    Vector3 Choose(char axis,int i)
    {
        if (axis == 'x')
            return new Vector3(-range/2 + i * interval, 0, 0);
        else if (axis == 'y')
            return new Vector3(0, -range/2 + i * interval, 0);
        else if (axis == 'z')
            return new Vector3(0, 0, -range/2 + i * interval);
        else
            return new Vector3(0,0,0);
    }
}
