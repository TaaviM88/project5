using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class EndingCanvasButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	

	public void SetEndingCanvasButton()
	{
		EventSystem.current.SetSelectedGameObject(this.gameObject);

	}
}
