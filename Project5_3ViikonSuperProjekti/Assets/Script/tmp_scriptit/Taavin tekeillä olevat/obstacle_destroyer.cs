using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle_destroyer : MonoBehaviour {

    public ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;

	// Use this for initialization
	void Start () {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
	}

    void Update()
    {
    }
	
	// Update is called once per frame
    void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);

        ///Rigidbody rb = other.GetComponent<Rigidbody>();
        int i = 0;

        while (i < numCollisionEvents)
        {
            if (other != null && other.gameObject.tag != "Player")
            {
                Bullet bullet = GetComponent<Bullet>();
                if (bullet != null)
                {
                    
                   bullet.StopBullet();
                    Debug.Log(other);
                }
                //Destroy(other.gameObject);
            }
           /* Player _player = GetComponent<Player>();
            if (_player != null)
            {
                _player.ILostGame();
            }*/
            if (other.gameObject.tag == "Player")
            {
                Bullet bullet = GetComponent<Bullet>();
                if (bullet != null)
                {

                    bullet.StopBullet();
                    Debug.Log(other);
                }
                //Destroy(other.gameObject);
                Player _player = other.gameObject.GetComponent<Player>();
                _player.PlayerDie();
            }
            /*if (rb)
            {
                Vector3 pos = collisionEvents[i].intersection;
                Vector3 force = collisionEvents[i].velocity * 10;
                rb.AddForce(force);
            }*/
            i++;
        }
    }
}
