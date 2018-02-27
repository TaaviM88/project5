using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardImage_controller : MonoBehaviour {
RectTransform rect;

	// Use this for initialization
	void Start () {
		rect = GetComponent<RectTransform>();
		
	}
	
	public void ResizeSize()
	{
	rect.sizeDelta = new Vector2(130,170);
	}
}
