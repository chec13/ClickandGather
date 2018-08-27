using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseOverUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool mouseIsOver = false;
    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseIsOver = true;
        Debug.Log("MouseOver");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("MouseExit");
        mouseIsOver = false;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
