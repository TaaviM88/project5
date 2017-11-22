using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerType
{
    player1, player2
}
public class GameManager : MonoBehaviour {
    public static GameManager gamemanager;
    List<Player> listPlayers;
	// Use this for initialization
	void Awake () {
        gamemanager = this;
        listPlayers = new List<Player>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void AddPlayer(Player player)
    {
        listPlayers.Add(player);
    }
    public Player Getplayer(PlayerType player)
    {
        for( int i = 0; i<listPlayers.Count; i++ )
        {
            //vertaa pelaajan tyyppiä PlayerType player
       //     if(player)
            
        }
        return null;
    }
}
