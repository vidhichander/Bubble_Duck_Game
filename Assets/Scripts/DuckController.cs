using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckController : MonoBehaviour
{
    #region Cached References
    private Animator cr_Anim;
    private Renderer cr_Renderer;
    private Rigidbody cc_Rb;
    #endregion

    #region Private Components 
    private float m_Speed;
    private Camera cam;
    private float halfHeight;
    private float halfWidth;
    private float horizontalMin;
    private float horizontalMax;
    #endregion


    #region Initialization
    private void Awake()
    {
        cam = Camera.main;
        halfHeight = cam.orthographicSize;
        halfWidth = cam.aspect * halfHeight;
        horizontalMin = -halfWidth;
        horizontalMax = halfWidth;

        m_Speed = 0.07f;
        cc_Rb = GetComponent<Rigidbody>();
        cr_Anim = GetComponent<Animator>();
        cr_Renderer = GetComponentInChildren<Renderer>();
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    #endregion

    #region Updates
    private void Update()
    {
        float right = Input.GetAxis("Horizontal");

        this.transform.Translate(m_Speed * right, 0, 0);


        if (transform.position.x > horizontalMax)
        {
            transform.position = new Vector3(horizontalMax, transform.position.y);
        }
        if (transform.position.x < horizontalMin+2)
        {
            transform.position = new Vector3(horizontalMin+2, transform.position.y);
        }

    }
    #endregion


}

