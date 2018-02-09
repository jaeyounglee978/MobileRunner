using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
	float radius = 0.2f;
	public float cameraZoomTime;
	float zoomTime;
	public GameObject player;
	IEnumerator cameraCoroutine;
	bool cameraCoroutineRunning;
	public bool cameraWork;

	// Use this for initialization
	void Start ()
	{
		//cameraCoroutine = CameraShake();
		cameraWork = false;
	}

	void FixedUpdate()
	{
		if (Input.GetKeyDown (KeyCode.Space))
			CameraShake ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (cameraWork) {
			if (player.transform.position.y > 0) {
				//transform.position = new;
				GetComponent<Camera> ().orthographicSize = 5.0f + player.transform.position.y / 2;
			} else {
				transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, transform.position.z);
			}

			if (zoomTime > 0) {
				Vector2 p = Random.insideUnitCircle * radius;
				transform.position = new Vector3 (transform.position.x + p.x, transform.position.y + p.y, transform.position.z);
				GetComponent<Camera> ().orthographicSize = 5.0f - zoomTime * (4.0f / cameraZoomTime);
				zoomTime -= Time.deltaTime;
			
				if (zoomTime < 0) {
					GetComponent<Camera> ().orthographicSize = 5;
					GetComponent<Camera> ().transform.position.Set (0, 0, -10);
					zoomTime = 0;
				}
			}
		}
	}

	public IEnumerator CameraStart()
	{
		while ((transform.position - player.transform.position).magnitude <= 0.05f)
		{
			transform.position = Vector3.MoveTowards (transform.position,
													new Vector3(player.transform.position.x, player.transform.position.y, -10),
													0.0001f * Time.deltaTime);
			yield return new WaitForEndOfFrame ();
		}

		cameraWork = true;
		yield return null;
	}

	void CameraShake()
	{
		zoomTime = cameraZoomTime;
	}
}
