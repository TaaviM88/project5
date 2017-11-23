using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour {
    public float DestroyTime = 5f;
	// Use this for initialization
	void Start () {

        Invoke("DestroySelf",DestroyTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
