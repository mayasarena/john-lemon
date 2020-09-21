using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;
    public GameEnding gameEnding;
    bool m_IsPlayerInRange;

    void OnTriggerEnter(Collider other) // checking if the player enters the range of the enemy
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other) // checking if the player exits the range of the enemy
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }

    void Update() 
    {
        if(m_IsPlayerInRange) // if the player is in range, check if the enemy can see them using a raycast
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            if(Physics.Raycast(ray, out raycastHit))
            {
                if(raycastHit.collider.transform == player && !FindObjectOfType<InvincibilityManager>().invincibleSatus()) // check if player is hit by ray and not invincible
                {
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }
}
