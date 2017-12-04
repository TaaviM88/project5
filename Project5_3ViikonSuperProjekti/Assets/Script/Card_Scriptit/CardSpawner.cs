using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour {
    Card[] CardsPrefabs;
    List<Card> _cards =  new List<Card>();
    public int CardAmountRandomised = 6;
    public int CardCopies = 2;
    public bool CardRandomizer = false;
	// Use this for initialization
	void Start () {
        CardsPrefabs = Resources.LoadAll<Card>("Cards");
        if (CardRandomizer == true)
        {
            RandomizeCards();
        }
        else { CreateCards(); }
        
	}

    //Luo kortteja. J merkkaa montako samaa korttia luodaan
    public void CreateCards()
    {
        for (int i = 0; i < CardsPrefabs.Length; i++)
        {
            //CardCopies = montako kopiota yhdestä kortista tehdään
            for (int j = 0; j < CardCopies; j++)
            {
                _cards.Add(Instantiate(CardsPrefabs[i], transform));
            }
        }
    }
    // randomisti antaa kortteja
    public void RandomizeCards()
    {
        for (int i = 0; i < CardAmountRandomised; i++)
        {
            int randomindex = Random.Range(0, CardsPrefabs.Length);
                _cards.Add(Instantiate(CardsPrefabs[randomindex], transform));
        }
    }
}
