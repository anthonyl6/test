using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour {

	//configuration params
	[Range(0.1f,10f)] [SerializeField] float gameSpeed = 1f;
	[SerializeField] int pointsPerBlockDestroy = 83;
	[SerializeField] TextMeshProUGUI scoreText;

	//state variables
	[SerializeField] int currentScore = 0;
	[SerializeField] bool isAutoPlayEnabled;


	private void Awake() 
	{
		int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
		if(gameStatusCount > 1) 
		{
			Destroy(gameObject);
		} 
		else
		{
			DontDestroyOnLoad(gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		scoreText.text = currentScore.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		Time.timeScale = gameSpeed;

	}

	public void AddToScore() 
	{
		currentScore += pointsPerBlockDestroy;
		scoreText.text = currentScore.ToString();
	}

	public void ResetGame() 
	{
		Destroy(gameObject);
	}

	public bool IsAutoPlayEnabled()
	{
		return isAutoPlayEnabled;
	}
}
