using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Cam : MonoBehaviour
{
    //Take the target to follow
    [SerializeField] private Transform m_target;

    //Parameters to keep the target in frame while following it & maintaining a safe distance
    [SerializeField] private float m_distance = 5f, m_height = 3f, m_rotationDamp, m_heightDamp;

    private void LateUpdate()
    {
        //Check if the target is missing
        if (!m_target)
            return;

        //Get Current Angle & Height of the Camera
        var currentAngle = transform.eulerAngles.y;
        var currentHeight = transform.position.y;

        //Get Angle & Height of the Target 
        var targetAngle = m_target.eulerAngles.y;
        var targetHeight = m_target.position.y + m_height;

        //Apply Angle & Height Damp
        currentHeight = Mathf.Lerp(currentHeight, targetHeight, m_heightDamp * Time.deltaTime);
        currentAngle = Mathf.LerpAngle(currentAngle, targetAngle, m_rotationDamp * Time.deltaTime);

        //Convert the Calculated Angle to Rotation
        var currentRotation = Quaternion.Euler(0, currentAngle, 0);

        //Set the Position & Height of the Camera
        transform.position = m_target.position;
        transform.position -= currentRotation * Vector3.forward * m_distance;
        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

        //Always look at the Target
        transform.LookAt(m_target);
    }
}
