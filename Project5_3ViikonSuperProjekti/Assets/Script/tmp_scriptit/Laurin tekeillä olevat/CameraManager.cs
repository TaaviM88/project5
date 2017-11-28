using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

	public Transform player1, player2;
	public float minSizeY = 5f;

	void SetCameraPos() {
		Vector3 middle = (player1.position + player2.position) * 0.5f;

		GetComponent<Camera>().transform.position = new Vector3(
			middle.x,
			middle.y,
			GetComponent<Camera>().transform.position.z
		);
	}

	void SetCameraSize() {
		//Koko on näytön reso
		float minSizeX = minSizeY * Screen.width / Screen.height;


		float width = Mathf.Abs(player1.position.x - player2.position.x) * 0.85f;
		float height = Mathf.Abs(player1.position.y - player2.position.y) * 0.85f;

		//koon laskenta
		float camSizeX = Mathf.Max(width, minSizeX);
		GetComponent<Camera>().fieldOfView = Mathf.Max(height,
			camSizeX * Screen.height / Screen.width, minSizeY);
	}

	void Update() {
		SetCameraPos();
		SetCameraSize();
	}

}
