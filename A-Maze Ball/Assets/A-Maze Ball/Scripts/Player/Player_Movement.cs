using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    //Parameters to keep the Ball's movement in check
    [SerializeField] private float m_maxAngularVelocity = 25f, m_sensitivity = 5f;

    private Vector3 m_movement; //Variable to store the calculated Movemen Value
    private Rigidbody m_playerRigidBody; //RigidBody Component of the Player
    private Transform m_playerTransform; //Transform Component of the Player

    private void Awake()
    {
        //Initialize these on Awake to avoid null reference conflicts (if any occurs)
        m_playerRigidBody = this.GetComponent<Rigidbody>();
        m_playerTransform = this.transform;
    }

    private void Start()
    {
        //Set the max velocity at which the ball can rotate
        m_playerRigidBody.maxAngularVelocity = m_maxAngularVelocity;
    }

    private void Update()
    {
        //Get Input
        var horizontalMovement = Input.GetAxis("Horizontal");
        var verticalMovement = Input.GetAxis("Vertical");

        //Calculate Movement
        m_movement = ((verticalMovement * Vector3.forward) + (horizontalMovement * Vector3.right)).normalized;
    }

    private void FixedUpdate()
    {
        //Apply force to the Ball
        m_playerRigidBody.AddForce(m_movement * m_sensitivity);
    }
}
