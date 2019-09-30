using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReplayController : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("Region containing Current Score")]
    private Text m_Score;
    #endregion

    #region Initialization
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        m_Score.text = "Score: " + Score.Singleton.score;
    }
    #endregion

    #region Play Methods
    public void PlayArena()
    {
        SceneManager.LoadScene("GameMode");
    }
    #endregion


    #region General Applical Methods 
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    #endregion
}
