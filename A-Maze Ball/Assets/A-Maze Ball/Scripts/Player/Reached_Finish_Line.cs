using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reached_Finish_Line : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Check if the player has reached finised line
        if (other.gameObject.tag == "Player")
            Game_Manager._gameManager._hasFinished = true;
    }
}
