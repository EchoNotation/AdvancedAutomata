using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenSpotted : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject other = collider.gameObject;
        if (other.CompareTag("Scanner"))
        {
            other.GetComponent<Scanner>().EnterRange(this.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        GameObject other = collider.gameObject;
        if (other.CompareTag("Scanner"))
        {
            other.GetComponent<Scanner>().ExitRange(this.gameObject);
        }
    }
}
