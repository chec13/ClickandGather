using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldInfo : MonoBehaviour {
    GameObject g;
    Vector3 point;
    string Command;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void hold(GameObject obj, Vector3 walk_Point, string command)
    {
        g = obj;
        point = walk_Point;
        Command = command;
    }
   public void activateCommand()
    {
        GameObject temp = GameObject.FindGameObjectWithTag("Player");
        temp.GetComponent<player_move>().setTarget(point);
        if (Command == "Tree")
        {
            //temp.GetComponent<player_move>().target = point;
            
            temp.GetComponent<ChopTree>().chop(g);

        }
        if (Command == "Ground")
        {
            temp.GetComponent<player_move>().target = point;
        }
        if (Command == "AI")
        {
            temp.GetComponent<player_Attacking>().attackTarget(g);
        }
        //temp.GetComponent<player_move>().deactivateDropDown();
        transform.parent.GetComponent<DestroyChildren>().destroyChildren();
    }
}
