using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Inventory : MonoBehaviour {
    //public Camera mainCamera;
    public GameObject inventory;
    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void open()
    {
        inventory.SetActive(!inventory.activeSelf);
    }
}
