using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour {
    Card[] CardsPrefabs;
    List<Card> _cards =  new List<Card>();
    public int CardAmount = 6;
	// Use this for initialization
	void Start () {
        CardsPrefabs = Resources.LoadAll<Card>("Cards");
        CreateCards();
        //RandomizeCards();
	}

    public void CreateCards()
    {
        for (int i = 0; i < CardsPrefabs.Length; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                _cards.Add(Instantiate(CardsPrefabs[i], transform));
            }
        }
    }

    public void RandomizeCards()
    { 
        for (int i = 0; i < CardAmount; i++)
        {
            int randomindex = Random.Range(0, CardsPrefabs.Length);
                _cards.Add(Instantiate(CardsPrefabs[randomindex], transform));
        }
    }
}
