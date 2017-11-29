using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public enum PlayerType
{
    player1, player2
}*/

public class GameManager : MonoBehaviour {
    public static GameManager gamemanager;
    List<Player> listPlayers;
   public GameTypes.PlayerType _player;
   private Effect_Container _effectContainer;
   public Effect_Container Effectlist { get 
   {
       if (_effectContainer == null)
       {
           _effectContainer = Resources.Load<Effect_Container>("SpellEffectList");
       }
       return _effectContainer;
   } }
	// Use this for initialization
	void Awake () {
        gamemanager = this;
        listPlayers = new List<Player>();
        //StopTimeScale();  
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void AddPlayer(Player player)
    {
        listPlayers.Add(player);
    }
   
    public Player GetPlayer(GameTypes.PlayerType player)
    {
        foreach (var p in listPlayers)
        {
            if (p.playerType == player)
                return p;
        }
        return null;
    }
    public void StopTimeScale()
    {
        Time.timeScale = 0;
        Debug.Log("Aika pysäytetty" + Time.timeScale);
    }
    public void StartTimeScale()
    {
        Time.timeScale = 1;
        Debug.Log("Aika pysäytetty" + Time.timeScale);
    }

}
