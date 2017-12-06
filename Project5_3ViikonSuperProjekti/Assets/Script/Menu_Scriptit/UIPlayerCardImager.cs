using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIPlayerCardImager : MonoBehaviour {
    private Image cardImage;
	// Use this for initialization
	void Awake () {
        cardImage = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void CardImage(Image card)
    {
        cardImage.sprite = card.sprite;
    }
}
