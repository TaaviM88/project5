using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldAbility : MonoBehaviour {
    public float duration;
    float timer; 
	// Use this for initialization
	void Start () {
        timer = duration;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Death();
        }
	}

    public void Death()
    {
        Destroy(gameObject);
    }
}
