using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChopTree : MonoBehaviour {
    Animator a;
    NavMeshAgent agent;
    Tree tree;
    bool target_Set = false, in_Range = false;
    float checkTime = 1;
    Vector3 target;
    public GameObject hatchet;
    public GameObject bag;
	// Use this for initialization
	void Start () {
        a = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        //target = new Vector3();
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(agent.pathEndPosition + " " + target);
        if (target_Set)
        {
            if (target == agent.destination)
            {
                if (Vector3.Distance(agent.gameObject.transform.position, target) < 2)
                {
                    //started = true;
                    hatchet.SetActive(true);
                    gameObject.transform.LookAt(tree.transform);
                    a.SetBool("chopping", true);
                    if (checkTime <= 0)
                    {
                        int roll = Random.Range(1, 100);
                        if (roll > 80)
                        {
                            tree.getLog();
                            Debug.Log("You recieve a log");
                            bag.GetComponent<Bag>().addInventory(tree.code);
                            if (roll > 90)
                            {
                                Bag.myBag.addInventory("fr0120");
                                Debug.Log("Fire");
                            }
                        }
                        checkTime = 1;

                    }
                    else
                    {
                        checkTime -= Time.deltaTime;
                    }
                    if (!tree.alive)
                    {
                        tree = null;
                        a.SetBool("chopping", false);
                        target_Set = false;
                        hatchet.SetActive(false);
                        checkTime = 1;
                        Debug.Log("You have exhausted this resource");
                    }
                }
            }
            else
            {
                a.SetBool("chopping", false);
                target_Set = false;
                hatchet.SetActive(false);
                //isChopping = false;
            }
        }
        //if (!agent.isStopped && started)
        //{
        //    started = false;
        //    a.SetBool("chopping", false);
        //    isChopping = false;
        //}
	}
   public void chop (GameObject t)
    {
        tree = t.GetComponent<Tree>();
        
            if (tree.alive)
            {
                target_Set = true;
                              
            }
            else
            {
                Debug.Log("No more wood");
            }
        target = agent.destination;
        
        
    }
    
}
