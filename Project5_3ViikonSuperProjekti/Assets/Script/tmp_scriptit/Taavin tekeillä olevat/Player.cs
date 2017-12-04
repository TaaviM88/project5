using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public GameTypes.PlayerType playerType = GameTypes.PlayerType.None;
    PlayerSkillSet _skillset;
    public  List<Card> _cardList;
    Player _player;
	// Use this for initialization
	void Start () {
        _cardList = new List<Card>();
		GameManager.gamemanager.AddPlayer(this);
        Player _player = this;
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

    public bool RemoveCardFromPlayer(Card card)
    {
        if(_cardList.Count !=0)
        {
            _cardList.RemoveAt(0);
            return true;
        }
        return false;
    }

   void OnTriggerEnter(Collider col)
   {
       PlayerDie();
   }

   public void PlayerDie()
   {
       
       GameManager.gamemanager.Winner();
       Debug.Log("LUL KUOLIN SAATANA");
   }
}
