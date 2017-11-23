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
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void AddCardToPlayer(Card card)
    {
        _cardList.Add(card);
    }
 
   
}
