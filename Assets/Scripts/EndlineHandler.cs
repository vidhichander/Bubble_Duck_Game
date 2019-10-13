using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndlineHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Green Bubble" || other.tag == "Blue Bubble" || other.tag == "Red Bubble")
        {
            other.GetComponent<BubbleHandler>().endlineCollisions += 1;
        }
        if (other.GetComponent<BubbleHandler>().endlineCollisions >= 2)
        {
            GameObject duck = GameObject.FindWithTag("Player");
            duck.GetComponent<GameManager>().LoseGame();
        }
    }
}
