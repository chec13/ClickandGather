using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ai_Handler : MonoBehaviour {
    // public int health = 100, damage = 10;
    float fire_Rate;
    public bool canAttack = true;
    public GameObject[] waypoints;
    public int current_waypoint = 0;
    float fire_Timer;
    Animator ai_anim;
    GameObject attack_target;
    NavMeshAgent ai_nav;
    attributes ai_attributes;
	// Use this for initialization
	void Start () {
        ai_anim = GetComponent<Animator>();
        ai_anim.SetBool("walking", true);
        ai_nav = GetComponent<NavMeshAgent>();
        ai_attributes = GetComponent<attributes>();
        ai_nav.speed = ai_attributes.movement_speed;
        fire_Rate = ai_attributes.attack_rate;
	}
	
	// Update is called once per frame
	void Update () {
		if (ai_attributes.health <= 0)
        {
            ai_anim.SetBool("dieing", true);
        }
        else if (attack_target != null)
        {
            gameObject.transform.LookAt(attack_target.transform);
            if (fire_Timer <= 0)
            {
                //fire at target
                fire_Timer = fire_Rate;
            }
            else
            {
                fire_Timer -= Time.deltaTime;
            }
        }
        if (ai_anim.GetBool("walking"))
        {
            if (Vector3.Distance(waypoints[current_waypoint].transform.position, transform.position) < 4)
            {
                if (current_waypoint == waypoints.Length - 1)
                {
                    current_waypoint = 0;
                }
                else
                {
                    current_waypoint++;
                }
                ai_nav.SetDestination(waypoints[current_waypoint].transform.position);
            }
        }
    }
    public void gettingAttacked(GameObject attacker)
    {
        if (ai_attributes.health > 0)
        {
            attack_target = attacker;
            ai_anim.SetBool("attacking", true);
            ai_anim.SetBool("walking", false);
            ai_nav.Stop();
        }
        fire_Timer = fire_Rate;
    }
}
