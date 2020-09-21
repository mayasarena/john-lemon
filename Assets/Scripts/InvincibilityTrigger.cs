using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityTrigger : MonoBehaviour
{
    public float invincibilityLength;

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            FindObjectOfType<InvincibilityManager>().Trigger(invincibilityLength); // trigger invincibility
            Destroy(gameObject); // destroy the invicibility sphere
        }
    }
}
