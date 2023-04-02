using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{    
    [SerializeField] float m_torqueAmount = 1.0f;
    [SerializeField] float m_boostSpeed = 30.0f;
    [SerializeField] float m_baseSpeed = 20.0f;

    Rigidbody2D m_rigidBody;
    SurfaceEffector2D m_surfaceEffector2D;
    bool m_canMove = true;

    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody2D>();
        m_surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    void Update()
    {
        if (m_canMove)
        {
            rotatePlayer();
            respondToBoost();
        }
    }

    public void disableControls()
    {
        m_canMove = false;
    }

    private void respondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            m_surfaceEffector2D.speed = m_boostSpeed;
        else
            m_surfaceEffector2D.speed = m_baseSpeed;
    }

    private void rotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            m_rigidBody.AddTorque(m_torqueAmount);
        else if (Input.GetKey(KeyCode.RightArrow))
            m_rigidBody.AddTorque(-m_torqueAmount);
    }
}
