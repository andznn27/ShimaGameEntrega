using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkground : MonoBehaviour
{
    public static bool isgrounded;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isgrounded = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isgrounded = false;
    }
}
