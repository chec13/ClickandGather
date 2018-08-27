using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_Attacking : MonoBehaviour {
    GameObject target;
    public GameObject projectile;
    float fire_rate, timer;
    public GameObject projectile_parent;
    // Use this for initialization
    void Start () {
        fire_rate = gameObject.GetComponent<attributes>().attack_rate;
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<Animator>().GetBool("attacking"))
        {
            transform.LookAt(target.transform);
            if (timer <= 0)
            {
                fireAt(target);
                timer = fire_rate;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
	}
    public void attackTarget(GameObject g)
    {
        target = g;
        g.GetComponent<Ai_Handler>().gettingAttacked(gameObject);
        gameObject.GetComponent<Animator>().SetBool("attacking", true);
        gameObject.GetComponent<Animator>().SetBool("running", false);
    }
    public void fireAt(GameObject target)
    {
        GameObject p = Instantiate<GameObject>(projectile, projectile_parent.transform);
        p.transform.position += Vector3.forward;
        p.GetComponent<projectile>().fire(target);
    }
    
}
