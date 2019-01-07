using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour {

    Level level;

	public void OnTriggerEnter2D(Collider2D collision) 
    {
        level = FindObjectOfType<Level>();
        level.RemoveBalls();

        SceneManager.LoadScene("Game Over");
        }
    }
