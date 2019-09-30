using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class Score : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("The text component that is displaying the score. The text value " +
       "of this component will change with the score.")]
    private Text m_UIText;
    #endregion

    #region Non-Editor Variables
    private int m_Score;
    public int score
    {
        get
        {
            return m_Score;
        }
    }
    #endregion

    #region Singletons
    private static Score st;
    #endregion

    #region First Time Initialization and Set Up
    private void Awake()
    {
        m_Score = 0;
        st = this;
    }

    public void Start()
    {
        AddScore(0);
    }
    #endregion

    #region Accessors and Mutators
    public static Score Singleton
    {
        get { return st; }
    }
    #endregion

    #region Score Modification Methods
    public void AddScore(int add)
    {
        m_Score += add;
        m_UIText.text = "" + m_Score;
        if (m_Score < 0)
        {
			GameObject duck = GameObject.FindWithTag("Player");
			duck.GetComponent<GameManager>().LoseGame();
		}
    }
    #endregion

    #region Update HighScore
    private void UpdateHighScore()
    {
        if (!PlayerPrefs.HasKey("HS"))
        {
            PlayerPrefs.SetInt("HS", m_Score);
            return;
        }
        int hs = PlayerPrefs.GetInt("HS");
        if (hs < m_Score)
        {
            PlayerPrefs.SetInt("HS", m_Score);
        }

    }
    #endregion

    #region Destruction
    private void OnDisable()
    {
        UpdateHighScore();
    }
    #endregion

}