using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class player_move : MonoBehaviour{
    NavMeshAgent agent;
    Animator animator;
   public Vector3 target;
    public GameObject dropDown, dropDownLabel;
    
	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (target != null)
        agent.SetDestination(target);
        bool running = (agent.velocity.magnitude > 0) ? true : false;
        animator.SetBool("running", running);

        if (Input.GetMouseButtonUp(0))
        {
            deactivateDropDown();
            if (EventSystem.current.IsPointerOverGameObject())
            {
                //Debug.Log("Over");
            }
            else
            {
                RaycastHit[] hit;
                Ray point = Camera.main.ScreenPointToRay(Input.mousePosition);
                hit = Physics.RaycastAll(point, 30);
                for (int x = 0; x < hit.Length; x++)
                {
                    Debug.Log(hit[x].transform.gameObject.tag);
                    if (hit[x].transform.gameObject.tag == "Tree")
                    {
                        target = hit[x].point;
                        agent.SetDestination(target);
                        GetComponent<ChopTree>().chop(hit[x].transform.gameObject);

                        break;
                    }
                    if (hit[x].transform.gameObject.tag == "Ground")
                    {
                        target = hit[x].point;
                    }
                    if (hit[x].transform.gameObject.tag == "AI")
                    {
                        GetComponent<player_Attacking>().attackTarget(hit[x].transform.gameObject);
                    }
                }
            }
        }
        else if (Input.GetMouseButtonUp(1))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                //Debug.Log("Over");
            }
            else
            {
                RaycastHit[] hit;
                Ray point = Camera.main.ScreenPointToRay(Input.mousePosition);
                hit = Physics.RaycastAll(point, 30);
                dropDown.GetComponent<followMouse>().activate();
                
                for (int x = 0; x < hit.Length; x++)
                {
                    Debug.Log(hit[x].transform.gameObject.tag);
                    if (hit[x].transform.gameObject.tag == "Tree")
                    {
                       // target = hit[x].point;
                       // agent.SetDestination(target);
                       // GetComponent<ChopTree>().chop(hit[x].transform.gameObject);
                    GameObject temp = Instantiate<GameObject>(dropDownLabel, dropDown.GetComponentInChildren<ScrollRect>().content.transform);
                        Vector2 buttonLocation = temp.transform.position;
                        buttonLocation.y = buttonLocation.y - (20 * x);
                        temp.transform.position = buttonLocation;
                        temp.GetComponent<HoldInfo>().hold(hit[x].transform.gameObject, hit[x].point, "Tree");
                        temp.GetComponentInChildren<Text>().text = "Chop Tree";
                        
                    }
                    if (hit[x].transform.gameObject.tag == "Ground")
                    {
                        GameObject temp = Instantiate<GameObject>(dropDownLabel, dropDown.GetComponentInChildren<ScrollRect>().content.transform);
                        Vector2 buttonLocation = temp.transform.position;
                        buttonLocation.y = buttonLocation.y - (20 * x);
                        temp.transform.position = buttonLocation;
                        temp.GetComponent<HoldInfo>().hold(hit[x].transform.gameObject, hit[x].point, "Ground");
                        temp.GetComponentInChildren<Text>().text = "Walk Here";
                        // target = hit[x].point;
                    }
                    if (hit[x].transform.gameObject.tag == "AI")
                    {
                        GameObject temp = Instantiate<GameObject>(dropDownLabel, dropDown.GetComponentInChildren<ScrollRect>().content.transform);
                        Vector2 buttonLocation = temp.transform.position;
                        buttonLocation.y = buttonLocation.y - (20 * x);
                        temp.transform.position = buttonLocation;
                        temp.GetComponent<HoldInfo>().hold(hit[x].transform.gameObject, hit[x].point, "AI");
                        temp.GetComponentInChildren<Text>().text = "Attack Target";
                    }
                }
            }

        }
	}
    public void setTarget(Vector3 v)
    {
        target = v;
        agent.SetDestination(target);
    }
    public void deactivateDropDown()
    {
        dropDown.SetActive(false);
    }
    
}
