using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour {
    public GameObject target;
    public float horizontal_Sensitivity = 1, vertical_Sensitivity = 1;
    float zoom = 5, horizontal_mod = 0, vertical_mod = 0;
    Vector3 position;
	// Use this for initialization
	void Start () {
        //position = target.transform.position;
        //position.x += zoom;
        //gameObject.transform.position = position;
        //gameObject.transform.LookAt(target.transform);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (vertical_mod < 90)
                vertical_mod+= vertical_Sensitivity;
                   
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (vertical_mod > 10)
                vertical_mod-= vertical_Sensitivity;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontal_mod-= horizontal_Sensitivity;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontal_mod+= horizontal_Sensitivity;
        }
        zoom -= Input.GetAxis("Mouse ScrollWheel");
        position.x = (Mathf.Cos(Mathf.Deg2Rad * horizontal_mod) * zoom) + target.transform.position.x;
        position.z = (Mathf.Sin(Mathf.Deg2Rad * horizontal_mod) * zoom) + target.transform.position.z;
        position.y = (Mathf.Sin(Mathf.Deg2Rad * vertical_mod) * zoom) + target.transform.position.y;
        gameObject.transform.position = position;
        gameObject.transform.LookAt(target.transform);
	}
}
