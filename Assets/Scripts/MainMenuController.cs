using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("Region containing HS")]
    private Text m_highScore;
    #endregion

    #region Private Variables
    private string m_defaultHighScore;
    #endregion

    #region Initialization
    // Start is called before the first frame update
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        m_defaultHighScore = m_highScore.text;
    }
    private void Start()
    {
        UpdateHighScore();
    }
    #endregion

    // Update is called once per frame
    #region Play Methods
    public void PlayArena()
    {
        SceneManager.LoadScene("GameMode");
    }
    #endregion

    #region General Applical Methods 
    public void Quit()
    {
        Application.Quit();
    }

    public void Rules()
    {
        SceneManager.LoadScene("Rules");
    }
    #endregion

    #region High Score Methods
    private void UpdateHighScore()
    {
        if (PlayerPrefs.HasKey("HS"))
        {
            m_highScore.text = m_defaultHighScore.Replace("%S", PlayerPrefs.GetInt("HS").ToString());
        }
        else
        {
            PlayerPrefs.SetInt("HS", 0);
            m_highScore.text = m_defaultHighScore.Replace("%S","0");
        }
    }

    public void ResetHighScore()
    {
        PlayerPrefs.SetInt("HS", 0);
        UpdateHighScore();
    }
    #endregion
}
