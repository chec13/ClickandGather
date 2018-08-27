using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bag : MonoBehaviour {
    GameObject[] r;
    int nextFreeSlot = 1;
    public static Bag myBag;
    //public Dictionary<string, Texture> objectLookup;
    //Use ObjectCodes.codes to get dictionary
    bool fullInventory = false;
	// Use this for initialization
	void Start () {
        List<GameObject> inventory = new List<GameObject>();
        for (int x = 1; x < transform.childCount; x++)
        {
            inventory.Add(transform.GetChild(x).GetChild(0).gameObject);
        }
        r = inventory.ToArray();
        calculateNextSlot();
        myBag = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void addInventory(string obj, int slot)
    {

    }
    public void addInventory(string obj)
    {
        if (!fullInventory)
        {
            GameObject temp = r[nextFreeSlot].gameObject;
            temp.SetActive(true);
            Image i = temp.GetComponent<Image>();
            i.sprite = ObjectCodes.getSprite(obj);
            i.SetNativeSize();
            i.color = Color.white;
            Debug.Log(i.gameObject.transform.position);

           // r[nextFreeSlot].texture = ObjectCodes.getTex(obj);
            calculateNextSlot();
        }
        else
        {
            Debug.Log("Inventory Full");
        }
    }
    public void removeObject(string obj, int slot)
    {

    }
    public void calculateNextSlot()
    {
        for (int x = 1; x < r.Length; x++)
        {
            if(!r[x].gameObject.activeSelf)
            {
                nextFreeSlot = x;
            }
        }
    }
    public Button getClosestButton()
    {
       
        
        for (int x = 1; x < transform.childCount; x++)
        {
            if (transform.GetChild(x).GetComponent<MouseOverUI>().mouseIsOver)
            {
                Debug.Log("returning a button");
                return transform.GetChild(x).GetChild(0).GetComponent<Button>();
                
            }

        }
        return null;
    }
    public void DeactivateSlot(GameObject g)
    {
        g.SetActive(false);
        calculateNextSlot();
    }
    

}
