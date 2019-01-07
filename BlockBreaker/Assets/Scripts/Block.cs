using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class Block : MonoBehaviour {

	//config params
	[SerializeField] AudioClip breakSound;
	[SerializeField] GameObject blockSparklesVFK;
	
	[SerializeField] Sprite[] hitSprites;

	//cached reference
	Level level;
	SceneLoader sceneLoader;
	Timer timeToBeat;

	//state variables
	[SerializeField] int timesHit; //serialized for debugging

	private void Start() 
	{
		CountBreakableBlocks();
	}

	private void CountBreakableBlocks()
	{
		level = FindObjectOfType<Level>();

		if(tag == "Breakable") 
		{
			level.CountBlocks();
		}
	}

	public void OnCollisionEnter2D(Collision2D collision) 
	{
		if(tag == "Breakable") 
		{
			HandleHit();
		}	
	}

	private void HandleHit()
	{
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		
		if(timesHit >= maxHits)
		{
			DestroyBlock();
		}
		else
		{
			ShowNextHitSprite();
		}
	}

	private void ShowNextHitSprite()
	{
		int spriteIndex = timesHit - 1;
		if(hitSprites[spriteIndex] != null)
		{
			GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
		else
		{
			Debug.LogError("Block sprite is missing from array" + gameObject.name);
		}
	}

	private void DestroyBlock() 
	{
		PlayBlockDestroySFX();
		level.RemoveBreakableBlocks();
		Destroy(gameObject);
		TriggerSparklesVFK();

	}

	private void PlayBlockDestroySFX()
	{
		FindObjectOfType<GameStatus>().AddToScore();
		AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
	}

	private void TriggerSparklesVFK()
	{
		GameObject sparkles = Instantiate(blockSparklesVFK, transform.position, transform.rotation);
		Destroy(sparkles, 1f);
	}

}
