using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseClickedInventory : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    int count = 0;
    bool OverButton = false;
    bool ObjectSelected = false;
    Sprite hold;
    // Use this for initialization
    void Start () {
        GetComponent<Button>().onClick.AddListener(mouseClick);
        hold = GetComponent<Button>().image.sprite;
    }
	
	// Update is called once per frame
	void Update () {
        
		if(Input.GetMouseButton(0) && ObjectSelected)
        {
            if (OverButton)
            {
                GetComponent<Button>().image.color = Color.white;
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            }
            else
            {
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                Button b = Bag.myBag.getClosestButton();
                Debug.Log(b);
                if (b)
                {
                    b.image.sprite = hold;
                    b.image.SetNativeSize();
                    b.image.color = Color.white;
                    b.gameObject.SetActive(true);
                    
                }
                GetComponent<Button>().image.sprite = null;
                Bag.myBag.DeactivateSlot(gameObject);
            }
            ObjectSelected = false;
        }
	}
    public void mouseClick()
    {
        hold = GetComponent<Button>().image.sprite;
        count++;
        if (count % 2 == 1)
        {
            Cursor.SetCursor(hold.texture, new Vector2(0, 0), CursorMode.Auto);
            GetComponent<Button>().image.color = Color.clear;
            ObjectSelected = true;
            //GetComponent<Button>().image.sprite = null;
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OverButton = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        OverButton = true;
    }
    //public void OnMouseExit()
    //{
    //    if (Input.GetMouseButtonUp(0))
    //    {
    //        GetComponent<SpriteRenderer>().sprite = null;
    //        gameObject.SetActive(false);
    //    }
    //}
    //public void eventss()
    //{

    //}

}
