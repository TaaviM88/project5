using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_RandomizedButton : MonoBehaviour {

    Card[] CardsPrefabs;
    List<Card> _cards = new List<Card>();
    public int CardAmountRandomised = 6;
    public int CardCopies = 2;
    public bool CardRandomizer = false;
    private Player _player;

    // Use this for initialization
    void Start()
    {
        CardsPrefabs = Resources.LoadAll<Card>("Cards");
        //RandomizeCardsButton();
   }

    
    // randomisti antaa kortteja
    public void RandomizeCardsButton()
    {
        RandomizePlayer1();
        RandomizePlayer2();
       
    }
    // Player 1 korttien antaminen
    void RandomizePlayer1()
    {
        for (int i = 0; i < CardAmountRandomised; i++)
        {
            int randomindex = Random.Range(0, CardsPrefabs.Length);
            _player = GameManager.gamemanager.GetPlayer(GameTypes.PlayerType.player1);
            if (_player._cardList.Count <= 5)
            {
                Card _card = GetComponent<Card>();
                _card = CardsPrefabs[randomindex];
                _player.AddCardToPlayer(_card);
            }
            
        }
    }
    // Player 2 korttien antaminen
    void RandomizePlayer2()
    {
        for (int i = 0; i < CardAmountRandomised; i++)
        {
            int randomindex = Random.Range(0, CardsPrefabs.Length);
            _player = GameManager.gamemanager.GetPlayer(GameTypes.PlayerType.player2);
            if (_player._cardList.Count <=5)
            {
                Card _card = GetComponent<Card>();
                _card = CardsPrefabs[randomindex];
                _player.AddCardToPlayer(_card);
            }
                
        }
    }
}
