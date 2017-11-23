using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimeController : MonoBehaviour
{
  
    private Animator anime;
    private Rigidbody rigidbody;

    // Use this for initialization
    void Start()
    {
        //controller = GetComponent<CharacterController>();
		anime = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
	//idle animaatio päällä
	public void StanceAnimation()
	{
		anime.SetBool ("Stance", true);
	}
		
	public void RunAnimation()
	{
		anime.SetBool ("Run", true);
	}

	public void JumpAnimation()
	{
		Debug.Log("hyppyanimaatio");
		anime.SetTrigger("Jump");
	}

	public void FallingAnimation ()
	{
		anime.SetBool ("Falling", true);
	}
}
