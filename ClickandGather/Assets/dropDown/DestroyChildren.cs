using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyChildren : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void destroyChildren()
    {
        for(int x = 0; x < transform.childCount; x++)
        {
            Destroy(transform.GetChild(x).gameObject);
        }
    }
}
