using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public GameTypes.PlayerType playerType = GameTypes.PlayerType.None;
    PlayerSkillSet _skillset;
    public  List<Card> _cardList;
    bool isdead = false;
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
       Debug.Log("Ai perkele muhun osu");
       PlayerDie();
   }

   void OnTriggerStay(Collider col)
   {
       Debug.Log("Olen pelaajan sisällä");
   }
   void OnTriggerExit(Collider col)
   {
       Debug.Log("lähdin pelaajasta");
   }
   public void PlayerDie()
   {
       if (isdead == false)
       {
           GameManager.gamemanager.Winner(this);
           Debug.Log("LUL KUOLIN SAATANA");
           isdead = true;
       }
   }
}
