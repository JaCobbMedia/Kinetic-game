using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour {

    private bool isTriggered = false;

    void Update () {
        if (isTriggered)
            killPlayer(GameObject.FindGameObjectWithTag("Player"));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(IsPlayer(collision))
        {
            isTriggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(IsPlayer(collision))
        {
            isTriggered = false;
        }
    }

    private bool IsPlayer(Collider2D collision)
    {
        return collision.tag == "Player";
    }

    public void killPlayer(GameObject hitTarget)
    {
        //Destroy(hitTarget);
        hitTarget.GetComponent<PlayerStatus>().TakeDamage(200f);
    }
}