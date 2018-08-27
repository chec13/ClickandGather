using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour {
    int amount;
    float respawn_Time = 10;
    public Texture tree_Icon;
    public string code = "tr0120";
    public bool alive = true;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		if (amount <= 0)
        {
            alive = false;
            transform.GetChild(0).transform.gameObject.SetActive(false);
            amount = Random.Range(1, 5);
        }
        if (!alive)
        {
            respawn_Time -= Time.deltaTime;
            if (respawn_Time < 0)
            {
                alive = true;
                respawn_Time = 10;
                transform.GetChild(0).transform.gameObject.SetActive(true);
            }
        }
        
	}
    void OnEnable()
    {
        amount = Random.Range(1, 5);

    }
   public void getLog()
    {
        amount--;
        Debug.Log(amount);
    }
    void OnTriggerStay(Collider other)
    {
        
    }
}
