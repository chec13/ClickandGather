using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour {
    
    public GameObject target;
    float lifeTime = 5;
    bool reachedTarget = false;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
        lifeTime -= Time.deltaTime;
        if (!reachedTarget)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, target.transform.position + Vector3.up, 10 * Time.deltaTime);
        }
	}
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == target)
        Destroy(gameObject);
    }
    public void fire(GameObject t)
    {
        target = t;
        transform.LookAt(target.transform);
        
    }
    
    
    
}
