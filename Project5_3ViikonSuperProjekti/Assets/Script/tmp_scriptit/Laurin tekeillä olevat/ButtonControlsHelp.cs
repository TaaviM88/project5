using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControlsHelp : MonoBehaviour 
{
	public GameObject Ohje;
	public Button yourButton;
	bool isOhjeOn;

	void Awake()
	{
		isOhjeOn = false;
		Debug.Log ("ohje ei ole päällä");
		//Ohje.SetActive (false);
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);

	}

	void TaskOnClick()
	{
		if (isOhjeOn == false)
		{
			Debug.Log ("Ohje päällä");
			Ohje.SetActive(true);
			isOhjeOn = true;
		}
		else if (isOhjeOn == true)
		{
			Debug.Log ("ohje latettiin pois päältä");
			Ohje.SetActive(false);
			isOhjeOn = false;
		}
	}


	}
