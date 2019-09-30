using UnityEngine;
using System.Collections;

[System.Serializable]

public class BubbleSpawnerInfo : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("The bubble prefab to spawn. This is what will be instantiated each time.")]
    private GameObject m_BubblePrefab;


    [SerializeField]
    [Tooltip("# seconds before next bubble is spawned")]
    private float m_TimeToNextSpawn;


    [SerializeField]
    [Tooltip("# bubbles to spawn. 0 = endless enemies")]
    private int m_NumberToSpawn;

    #endregion

    #region Accessors and Mutators
    public GameObject BubblePrefab
    {
        get { return m_BubblePrefab; }
    }
    public float TimeToNextSpawn
    {
        get
        {
            return m_TimeToNextSpawn;
        }
    }
    public int NumberToSpawn
    {
        get
        {
            return m_NumberToSpawn;
        }
    }

    #endregion
}
