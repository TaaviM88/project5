using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIRoundOver : MonoBehaviour {
    private Text _text;
    bool _isWinnerAnnouced = false;
    Animation _anime;
	// Use this for initialization
   // public GameObject _1PlayerWinCount;
    //public GameObject _2PlayerWinCount;
	private void Awake  () {
        _text = GetComponentInChildren<Text>(true);
        _anime = GetComponent<Animation>();
        //gameObject.SetActive(false);
	}
	
	// Update is called once per frame
    public void Show(Player winner)
    {
        if(_isWinnerAnnouced == false)
        {
            string text = ""; //= "Round Over!";
            if (winner != null)
            {
                text += "\n" + winner.name + " Wins!";
            }
            _text.text = text;
            gameObject.SetActive(true);
            _isWinnerAnnouced = true;
        }
    }

    public void ShowNoOneWins()
    {
        if( _isWinnerAnnouced == false)
        {
         string text = ""; //= "Round Over!";
       
            text += "\n" +  " No winners!";
        
            _text.text = text;
            gameObject.SetActive(true);
            _isWinnerAnnouced = true;
        }
    }
}
