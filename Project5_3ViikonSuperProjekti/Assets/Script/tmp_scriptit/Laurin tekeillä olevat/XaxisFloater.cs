using UnityEngine;
using System.Collections;

public class XaxisFloater : MonoBehaviour {

	public float degreesPerSecond = 15.0f;
	public float amplitude = 0.5f;
	public float frequency = 1f;


	Vector3 posOffset = new Vector3 ();
	Vector3 tempPos = new Vector3 ();


	void Start () {

		posOffset = transform.position;
	}

	// Update is called once per frame
	void Update () {

		transform.Rotate(new Vector3(Time.deltaTime * degreesPerSecond, 0f, 0f), Space.World);

		tempPos = posOffset;
		tempPos.y += Mathf.Sin (Time.fixedTime * Mathf.PI * frequency) * amplitude;

		transform.position = tempPos;
	}
}
