using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RulesHandler : MonoBehaviour
{
    #region menu
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    #endregion
}
