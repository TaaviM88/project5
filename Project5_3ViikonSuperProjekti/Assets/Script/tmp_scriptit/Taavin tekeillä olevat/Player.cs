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
	// Use this for initialization
	void Start () {
        _cardList = new List<Card>();
		GameManager.gamemanager.AddPlayer(this);
        //_uicard =  GetComponent<UIPlayerCardImager>();
        _uicard = FindObjectOfType<UIPlayerCardImager>();
	}
	
	// Update is called once per frame
	void Update () {

        //Yritys hakea pelaajan tän hetkisen kortin ja piirtää se HUDIIN. 
        /*if (_cardList.Count != 0)
        {
            if (_uicard == null)
            {
                Debug.Log("VITTU KU EI LÖYDY");
                //_uicard = GetComponent<UIPlayerCardImager>();
            }
            else
            {
                Image _cardsprite = _cardList[0].GetComponent<Image>();
                Debug.Log(_cardsprite + "Korttikuva");
                _uicard.CardImage(_cardsprite, this);

            }
        }
        else { _uicard.NoCardLeft(this); }*/
       
	}
    public bool AddCardToPlayer(Card card)
    {
		if(_cardList.Count <=6)
		{
        _cardList.Add(card);
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
                Debug.Log(_cardsprite + "Korttikuva");
                _uicard.CardImage(_cardsprite, this);

            }
        }
        else { _uicard.NoCardLeft(this); }
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
			Instantiate (deathAnimation, transform.position, transform.rotation);
           GameManager.gamemanager.Winner(this);
           Debug.Log("LUL KUOLIN SAATANA");
           isdead = true;
       }
   }
}
