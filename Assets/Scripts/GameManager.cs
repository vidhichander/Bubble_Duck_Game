using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

	#region Replay Scene Transition
	public void Replay()
	{
		SceneManager.LoadScene("GameMode");
	}
	#endregion

	#region Game Over Scene
	public void LoseGame()
	{
		SceneManager.LoadScene("End Game");
	}
    #endregion


}

