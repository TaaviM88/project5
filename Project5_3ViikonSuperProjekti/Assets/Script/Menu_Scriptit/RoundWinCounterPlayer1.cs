using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class RoundWinCounterPlayer1	 : MonoBehaviour {
 private static bool _created = false;
private Text _text;
int winCount;
	// Use this for initialization
	void Awake () {
		if(!_created)
		{
			DontDestroyOnLoad(this.gameObject);
			_text = GetComponentInChildren<Text>(true);
			_text.text = "Wins" + winCount.ToString();
			_created = true;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		_text.text = "Wins: " + winCount.ToString();
	}

	public void AddWinCount()
	{
		winCount ++;
	}
}
