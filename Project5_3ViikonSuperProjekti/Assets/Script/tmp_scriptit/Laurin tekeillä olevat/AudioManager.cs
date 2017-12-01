using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	//Audio
	public static AudioManager audioManager;


	//Player audios
	public AudioClip wandSwing;
	public AudioClip jump;
	public AudioClip run;

	//Skill audios
	public AudioClip fireBall;
	public AudioClip fireArrow;
	public AudioClip iceArrow;
	public AudioClip iceStorm;
	public AudioClip plasmaBall;
	public AudioClip shieldBubble;

	public AudioSource source;

	// Use this for initialization
	void Awake () 
	{
		audioManager = this;
		source = GetComponent<AudioSource>();	
	}

	//Hahmon liikkumiseen liittyvät äänet -----------------------------------------------
	public void WandSwing ()
	{
		Debug.Log ("sauva heiluu");
		source.PlayOneShot(wandSwing);

	}

	public void JumpSound ()
	{
		source.PlayOneShot(jump);
	}

	public void RunSound ()
	{
		source.PlayOneShot(run);
	}
	//------------------------------------------------------------------------------------

	//Spelleihin liittyvät äänet----------------------------------------------------------
	public void FireBall ()
	{
		source.PlayOneShot(fireBall);
	}

	public void FireArrow()
	{
		source.PlayOneShot(fireArrow);
	}

	public void IceArrow ()
	{
		source.PlayOneShot(iceArrow);
	}

	public void IceStorm ()
	{
		source.PlayOneShot(iceStorm);
	}

	public void PlasmaBall ()
	{
		source.PlayOneShot(plasmaBall);
	}

	public void ShieldBubble ()
	{
		source.PlayOneShot(shieldBubble);
	}
}
