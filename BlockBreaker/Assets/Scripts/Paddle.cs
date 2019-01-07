using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	// configuration paramaters
	[SerializeField] float ScreenWidthInUnits = 16f;
	[SerializeField] float maxPos = 15f;
	[SerializeField] float minPos = 1f;

	//cached references
	GameStatus theGameSession;
	Ball theBall;

	// Use this for initialization
	void Start () {
		theGameSession = FindObjectOfType<GameStatus>();
		theBall = FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 paddlePosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		paddlePosition.x = Mathf.Clamp(GetXPos(), minPos, maxPos);
		transform.position = paddlePosition;
	}

	private float GetXPos()
	{
		if(theGameSession.IsAutoPlayEnabled())
		{
			return theBall.transform.position.x;
		}
		else
		{
			return Input.mousePosition.x / Screen.width * ScreenWidthInUnits;
		}
	}
}
