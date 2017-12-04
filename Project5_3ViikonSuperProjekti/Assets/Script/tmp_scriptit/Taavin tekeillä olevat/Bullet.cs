using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed = 3f;
    public int powerUpInt = 0;
    public float damage = 0f;
    public float timer = 10f;
    private Vector3 bulletMovement;
    private Vector3 bulletRotation;
    private int direction = 1;
	// Use this for initialization

    void Update()
    {
        transform.position +=  direction* bulletMovement;
        transform.localRotation *= Quaternion.Euler(bulletRotation);
    }
    void OnEnable()
    {
        //powerUpInt = PlayerShooting.current.powerUpCount;
        //määrittää ammusten ominaisuudet: liikerata,nopeus, vahingon teko
        switch (powerUpInt)
        {
            case 0:
                bulletMovement = Vector3.right * speed * Time.deltaTime;
                speed = 0;
                //bulletRotation = new Vector3(0, 0, 20 * speed * Time.deltaTime);
                //damage = 1;
                //GetComponent<SpriteRenderer>().sprite = _SpPowerup0;
                //GetComponent<CircleCollider2D>().radius = 1.25f;
                break;

            case 1:
                bulletMovement = new Vector3(0, 0, 0);
                /*bulletMovement = Vector3.right * speed * Time.deltaTime;
                bulletRotation = new Vector3(0, 0, 5 * speed * Time.deltaTime);*/
                //damage = 4;
                //GetComponent<SpriteRenderer>().sprite = _SpPowerup1;
                //GetComponent<CircleCollider2D>().radius = 0.21f;
                break;

            case 2:
                bulletMovement = new Vector3(0.50f * speed * Time.deltaTime, 0.05f * (Mathf.Sin(2 * Mathf.PI * speed * Time.time)), 0);
                bulletRotation = new Vector3(0, 0, 5 * speed * Time.deltaTime);
                //damage = 2;
                //GetComponent<SpriteRenderer>().sprite = _SpPowerup2;
                //GetComponent<CircleCollider2D>().radius = 0.21f;
                break;

            default:

                break;
        }

        Invoke("Destroy", timer);
    }

    void Destroy()
    {
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        CancelInvoke();
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            Destroy();
        }
    }
    public void ChangeDirection()
    {
        direction *= -1;
    }
    public void StopBullet()
    {
        speed = 0;
        bulletMovement = new Vector3(0, 0, 0);
    }
}
