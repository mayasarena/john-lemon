using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityManager : MonoBehaviour
{
    float invincibilityCounter;
    public float blinkTime;
    public GameObject player;
    bool isInvincible;

    void Update()
    {
        if (invincibilityCounter > 0) // decrement time
        {
            invincibilityCounter -= Time.deltaTime;
        }

        else // set invincibility as false if there's no time left
        {
            isInvincible = false;
        }
    }

    public void Trigger(float invincibilityLength) 
    {
        invincibilityCounter = invincibilityLength; // begin the counter
        isInvincible = true;
        StartCoroutine(BlinkPlayer()); // start the coroutine for blinking the character
    }

    IEnumerator BlinkPlayer() 
    {
        while(invincibleSatus())
        {
            player.transform.GetChild(0).gameObject.GetComponent<SkinnedMeshRenderer>().enabled = false;
            yield return new WaitForSeconds(blinkTime);
            player.transform.GetChild(0).gameObject.GetComponent<SkinnedMeshRenderer>().enabled = true;
            yield return new WaitForSeconds(blinkTime);
        }
    }

    public bool invincibleSatus()
    {
        return isInvincible;
    }
}
