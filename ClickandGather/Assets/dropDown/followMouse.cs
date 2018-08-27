using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followMouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    public void activate()
    {
        gameObject.SetActive(true);
        gameObject.transform.position = Input.mousePosition;
    }
}
