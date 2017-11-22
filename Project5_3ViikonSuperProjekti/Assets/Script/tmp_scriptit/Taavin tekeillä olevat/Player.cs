using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public enum PlayerType
    {
        player1, player2
    }
    PlayerSkillSet _skillset;
    List<Card> _cardList;
	// Use this for initialization
	void Start () {
        _cardList = new List<Card>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
