using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseColliderMulti : MonoBehaviour {

    Level level;

	public void OnTriggerEnter2D(Collider2D collision) 
    {
        level = FindObjectOfType<Level>();
        level.RemoveBalls();

        if(level.NumberOfBalls() <= 0)
        {
            Debug.Log("All balls are gone");
            SceneManager.LoadScene("Game Over");
        }
    }
}
