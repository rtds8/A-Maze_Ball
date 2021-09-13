using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            Game_Manager._gameManager._penalties++;
    }
}
