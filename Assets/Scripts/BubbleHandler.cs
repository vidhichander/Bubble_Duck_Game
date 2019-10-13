using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BubbleHandler : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("radius of bubble")]
    private float radius;

    #endregion

    #region Variables
    private float elapsedTime;
    private Vector3 startingPosition;
    private bool stuck;
    private List<GameObject> p_bluebubbles;
    public List<GameObject> bluebubbles
    {
        get
        {
            return p_bluebubbles;
        }
    }
    private List<GameObject> p_greenbubbles;
    public List<GameObject> greenbubbles
    {
        get
        {
            return p_greenbubbles;
        }
    }
    public int endlineCollisions;

    #endregion

    #region Initialization
    // Start is called before the first frame update
    void Start()
    {
        endlineCollisions = 0;
        p_bluebubbles = new List<GameObject>();
        p_greenbubbles = new List<GameObject>();
        stuck = false;
        elapsedTime = 0;
        transform.position = new Vector3(Random.Range(-6f, 6f), -5f);
        startingPosition = transform.position;
    }
    #endregion


    #region Main Updates
    // Update is called once per frame
    void Update()
    {
        if (stuck == false)
        {
            transform.position = startingPosition + new Vector3(0, radius * Mathf.Sin(0.2f * elapsedTime));
            elapsedTime += Time.deltaTime;

            if (transform.position.y > 7)
            {
                Destroy(gameObject);
            }

        }

    }

    #endregion


    #region Trigger Handler
    private void OnCollisionEnter2D(Collision2D other)
    {

        if(this.gameObject.tag == "Red Bubble" && (other.gameObject.transform.parent != null || other.gameObject.tag == "Player"))
        {
            if(other.gameObject.tag == "Green Bubble")
            {
                stuck = true;
                Destroy(this.gameObject);
                Destroy(other.gameObject);
                Score.Singleton.AddScore(1);

            }
            else if ((other.gameObject.tag == "Blue Bubble" || other.gameObject.tag == "Player" || other.gameObject.tag == "Red Bubble") && this.gameObject.transform.parent == null)
            {
                stuck = true;
                this.gameObject.transform.SetParent(other.gameObject.transform);
                this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                Score.Singleton.AddScore(-1);

            }
        }
            

        if (this.gameObject.tag == "Blue Bubble" && (other.gameObject.transform.parent != null || other.gameObject.tag == "Player"))
        {
            if ((other.gameObject.tag == "Blue Bubble" || other.gameObject.tag == "Green Bubble" || other.gameObject.tag == "Player" || other.gameObject.tag == "Red Bubble") && this.gameObject.transform.parent == null)
            {
                stuck = true;
                this.gameObject.transform.SetParent(other.gameObject.transform);
                this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
            if ((other.gameObject.tag == "Player"))
            {
                p_bluebubbles.Add(this.gameObject);
            }
            if (other.gameObject.tag == "Blue Bubble" && this.gameObject.transform.parent == other.gameObject.transform)
            {
                foreach (GameObject bubble in other.gameObject.GetComponent<BubbleHandler>().bluebubbles)
                {
                    p_bluebubbles.Add(bubble);
                }
                p_bluebubbles.Add(this.gameObject);
                if(p_bluebubbles.Count >= 5)
                {
                    Score.Singleton.AddScore(5);
                    foreach(GameObject bubble in p_bluebubbles)
                    {
                        Destroy(bubble);
                    }
                }
            }
        }

        if (this.gameObject.tag == "Green Bubble" && (other.gameObject.transform.parent != null || other.gameObject.tag == "Player"))
        {
            if (other.gameObject.tag == "Red Bubble")
            {
                stuck = true;
                Destroy(this.gameObject);
                Destroy(other.gameObject);
                Score.Singleton.AddScore(1);
            }
            else if ((other.gameObject.tag == "Player" || other.gameObject.tag == "Green Bubble" || other.gameObject.tag == "Blue Bubble") && this.gameObject.transform.parent == null)
            {
                stuck = true;
                this.gameObject.transform.SetParent(other.gameObject.transform);
                this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
            if ((other.gameObject.tag == "Player"))
            {
                p_greenbubbles.Add(this.gameObject);
            }
            if (other.gameObject.tag == "Green Bubble" && this.gameObject.transform.parent == other.gameObject.transform)
            {
                foreach (GameObject bubble in other.gameObject.GetComponent<BubbleHandler>().greenbubbles)
                {
                    p_greenbubbles.Add(bubble);
                }
                p_greenbubbles.Add(this.gameObject);
                if (p_greenbubbles.Count >= 5)
                {
                    Score.Singleton.AddScore(20);
                    foreach (GameObject bubble in p_greenbubbles)
                    {
                        Destroy(bubble);
                    }
                }
            }


        }
        if (transform.position.y <= -2.5 && gameObject.transform.parent!=null)
        {
			GameObject duck = GameObject.FindWithTag("Player");
			duck.GetComponent<GameManager>().LoseGame();
		}
    }
    #endregion


}
