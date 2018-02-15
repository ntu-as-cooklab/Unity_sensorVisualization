using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
    public Transform target;
    public float x;
    public float y;
    public float xSpeed = 150;
    public float ySpeed = 150;
    public float disSpeed = 300;
    public float distance = 300;
    public float minDistance = 0.1F;
    public float  maxdistance = 100000000;

    public float dt = 0.1F;

    private Quaternion rotationEuler;
    private Vector3 cameraPosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LateUpdate() {
        if (Input.anyKey)
        {
            x += Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
            y += Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;
        }
        if (x > 360)
        {
            x -= 360;
        }
        else if (x < 0)
        {
            x += 360;
        }

        distance -= Input.GetAxis("Mouse ScrollWheel") * disSpeed * Time.deltaTime;
        distance = Mathf.Clamp(distance, minDistance, maxdistance);

        rotationEuler = Quaternion.Euler(-y, x, 0);
        cameraPosition = rotationEuler * new Vector3(0, 0, -distance) + target.position;

        transform.rotation = rotationEuler;
        transform.position = cameraPosition;
    }

    void Awake() {
        int fps = (int)Mathf.Round(1 / dt);
        print("FPS = " + fps);
        Application.targetFrameRate = fps;
    }
}
