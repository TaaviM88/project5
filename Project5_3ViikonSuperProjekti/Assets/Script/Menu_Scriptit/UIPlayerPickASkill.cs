﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerPickASkill : MonoBehaviour {
    private Text _text;
	// Use this for initialization
	void Awake () {
		_text = GetComponent<Text>();
		_text.color = new Color32(0,95,255,255);
		string text = "";
		text =  "BLUE MAGE PICK A SKILL";
		_text.text = text;
	}
	
	public void Player2PickASkill()
	{
		string text = "";
		text =  "BLUE MAGE PICK A SKILL";
		_text.text = text;
		//_text.color = Color.blue;
		_text.color = new Color32(0,95,255,255);
	}

	public void Player1PickASkill()
	{
		string text = "";
		text = " RED MAGE PICK A SKILL";
		_text.text = text;
		_text.color = new Color32(255, 0, 30, 255);
		//_text.color = Color.red;
	}

}