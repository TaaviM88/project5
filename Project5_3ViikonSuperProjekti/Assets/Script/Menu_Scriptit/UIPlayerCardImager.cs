using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIPlayerCardImager : MonoBehaviour {
    private Image _Player1CardImage;
    private Image _Player2CardImage;
	// Use this for initialization
	void Awake () {

        _Player1CardImage = transform.Find("Player1").GetComponent<Image>();
        _Player2CardImage = transform.Find("Player2").GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void CardImage(Image card, Player player)
    {
        if (player.playerType == GameTypes.PlayerType.player1)
        {
            _Player1CardImage.sprite = card.sprite;
        }
        else
        {
            _Player2CardImage.sprite = card.sprite;
        }
    }

    public void NoCardLeft(Player player)
    {
        if (player.playerType == GameTypes.PlayerType.player1)
        {
            _Player1CardImage.CrossFadeAlpha(0, 2, true);
        }
        if (player.playerType == GameTypes.PlayerType.player2)
        {
            _Player2CardImage.CrossFadeAlpha(0, 2, true);
        }
    }
}
