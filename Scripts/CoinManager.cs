using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private void Update()
    {
        CoinCollected();
    }

    public void CoinCollected()
    {
        if (transform.childCount==0)
        {
            Debug.Log("No quedan mas monedas que agarrar");
        }
    }
}
