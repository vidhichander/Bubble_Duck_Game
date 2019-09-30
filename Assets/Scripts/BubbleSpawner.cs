using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("Bounds of the area")]
    private Vector3 m_Bounds;

    [SerializeField]
    [Tooltip("List of all Bubbles that can be spawned and their information")]
    private BubbleSpawnerInfo[] m_Bubbles;
    #endregion

    #region Initialization
    private void Awake()
    {
        StartSpawning();
    }
    #endregion

    #region Spawn Methods
    public void StartSpawning()
    {
        for (int i = 0; i < m_Bubbles.Length; i++)
        {
            StartCoroutine(Spawn(i));
        }
    }

    private IEnumerator Spawn(int enemyInd)
    {
        BubbleSpawnerInfo info = m_Bubbles[enemyInd];
        int i = 0;
        bool alwaysSpawn = false;
        if (info.NumberToSpawn == 0)
        {
            alwaysSpawn = true;
        }
        while (alwaysSpawn || i < info.NumberToSpawn)
        {
            yield return new WaitForSeconds(info.TimeToNextSpawn);
            float xVal = m_Bounds.x/2;
            float yVal = m_Bounds.y/2;

            Vector3 spawnPos = new Vector3(
                Random.Range(-xVal, xVal),
                Random.Range(-yVal, yVal), 0);

            spawnPos += transform.position;
            Instantiate(info.BubblePrefab, spawnPos, Quaternion.identity);
            if (!alwaysSpawn)
            {
                i++;
            }
        }
    }
    #endregion
}