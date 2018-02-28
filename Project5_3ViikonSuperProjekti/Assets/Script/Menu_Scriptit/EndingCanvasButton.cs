using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class EndingCanvasButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame

	public void SetEndingCanvasButton()
	{
		EventSystem.current.SetSelectedGameObject(this.gameObject);
		
	}
}
