using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour {
    public GameTypes.PlayerType playerType = GameTypes.PlayerType.None;
    PlayerSkillSet _skillset;
    UIPlayerCardImager _uicard;
    public  List<Card> _cardList;
	public GameObject deathAnimation;
    bool isdead = false;
    public int KillAxelY = -47;
	// Use this for initialization
	void Start () {
        _cardList = new List<Card>();
		GameManager.gamemanager.AddPlayer(this);
        _uicard = FindObjectOfType<UIPlayerCardImager>();
	}
	
	// Update is called once per frame
	void Update () {

        //Jos pelaajan y-korkeus on liian pieni ( tällä hetkeä -47), pelaaja kuolee
        if (this.transform.position.y <= KillAxelY)
        {
            PlayerDie();
        }
    }

    public bool AddCardToPlayer(Card card)
    {
		if(_cardList.Count <=6)
		{
        _cardList.Add(card);
            Debug.Log("Kortti lisätty");
            //tarkastetaan onko listassa yksi kortti, jos on niin käsketään UIPlayerCardImager.cs piirtää se HUD:iin
        if (_cardList.Count == 1)
        {
            DrawUICard();
        }
		return true;
		}
		return false;
    }

    public bool RemoveCardFromPlayer(Card card)
    {
        if(_cardList.Count !=0)
        {
            _cardList.RemoveAt(0);
            //piirtää uuden kortin HUD:iin
            DrawUICard();

            return true;
        }
        return false;
    }

    public void DrawUICard()
    {
        if (_cardList.Count != 0)
        {
            if (_uicard == null)
            {
                Debug.Log("VITTU KU EI LÖYDY");
                //_uicard = GetComponent<UIPlayerCardImager>();
            }
            else
            {
                Image _cardsprite = _cardList[0].GetComponent<Image>();
                _uicard.CardImage(_cardsprite, this);

            }
        }
        else { _uicard.NoCardLeft(this); }
    }
   void OnTriggerEnter(Collider col)
   {
     
       PlayerDie();
   }

   void OnTriggerStay(Collider col)
   {

   }
   void OnTriggerExit(Collider col)
   {


   }

  /* public void ToggleMovement()
   {
       if (this.playerType == GameTypes.PlayerType.player1)
            {
                pmovement.EnableDisablePlayerMovement();
                Debug.Log("player1 toggle");
            }
       if(this.playerType == GameTypes.PlayerType.player2)
            {
                p2movement.EnableDisablePlayerMovement2();
                Debug.Log("player2 toggle");
            }
   }*/

   public void PlayerDie()
   {
       if (isdead == false)
       {
		    Instantiate (deathAnimation, transform.position, transform.rotation);
            GameManager.gamemanager.Winner(this);
            //GameManager.gamemanager.EnablePlayerMovements();      
            Debug.Log("LUL KUOLIN SAATANA");
            isdead = true;
       }
   }
}
