using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public GameTypes.PlayerType playerType = GameTypes.PlayerType.None;
    PlayerSkillSet _skillset;
    List<Card> _cardList;
	// Use this for initialization
	void Start () {
        _cardList = new List<Card>();
		GameManager.gamemanager.AddPlayer(this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public bool AddCardToPlayer(Card card)
    {
		if(_cardList.Count <=6)
		{
        _cardList.Add(card);
		return true;
		}
		return false;
    }
 
   
}
