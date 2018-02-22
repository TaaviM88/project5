using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIRoundOver : MonoBehaviour {
    private Text _text;
	// Use this for initialization
	private void Awake  () {
        _text = GetComponentInChildren<Text>(true);
        //gameObject.SetActive(false);
	}
	
	// Update is called once per frame
    public void Show(Player winner)
    {
        string text = ""; //= "Round Over!";
        if (winner != null)
        {
            text += "\n" + winner.name + " Wins!";
        }
        _text.text = text;
        gameObject.SetActive(true);
    }

    public void ShowNoOneWins()
    {
        string text = ""; //= "Round Over!";
       
            text += "\n" +  " No winners!";
        
        _text.text = text;
        gameObject.SetActive(true);
    }
}
