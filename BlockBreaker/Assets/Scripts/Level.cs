using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {
	//parameters
	[SerializeField] int numberOfBlocks; // serialized for debugging
	[SerializeField] int numberOfBalls; // serialized for debugging

	//cached reference
	SceneLoader sceneLoader;

	private void Start() 
	{
		sceneLoader = FindObjectOfType<SceneLoader>();
	}

	public void CountBlocks() 
	{
		numberOfBlocks++;
	}

	public void CountBalls()
	{
		numberOfBalls++;
	}

	public int NumberOfBalls()
	{
		return numberOfBalls;
	}

	public void RemoveBalls()
	{
		numberOfBalls--;
		Debug.Log("You lost a ball noob");
	}
	public void RemoveBreakableBlocks() 
	{
		numberOfBlocks--;
		if(numberOfBlocks <= 0) 
		{
			sceneLoader.LoadNextScene();
		}	
	}
}
