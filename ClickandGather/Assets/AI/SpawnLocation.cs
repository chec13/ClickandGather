using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnLocation : MonoBehaviour {
    public GameObject[] waypoints;
    int current_waypoint = 0;
    public string spawn_object;
    public float spawn_time;
    float current_time;
    bool startCountDownToSpawn = false;
    GameObject npc;
    Animator npc_animator;
    NavMeshAgent npc_nav;
	// Use this for initialization
	void Start () {
        spawnNpc();
        //npc_nav.speed = npc.GetComponent<Ai_Handler>().speed;
        npc_nav.SetDestination(waypoints[current_waypoint].transform.position);
        npc.GetComponent<Ai_Handler>().waypoints = waypoints;
	}
	
	// Update is called once per frame
	void Update () {
        if (!startCountDownToSpawn)
        {
            if (npc_animator.GetBool("dieing"))
            {
                current_time = spawn_time;
                startCountDownToSpawn = true;
            }
           
        }
        else
        {
            if (current_time <= 0)
            {
                startCountDownToSpawn = false;
                spawnNpc();
            }
            else
            {
                current_time -=Time.deltaTime;
            }
        }
	}
    public void spawnNpc()
    {
        npc = Instantiate<GameObject>(ObjectCodes.getObject(spawn_object));
        npc_animator = npc.GetComponent<Animator>();
        npc_nav = npc.GetComponent<NavMeshAgent>();
    }
}
