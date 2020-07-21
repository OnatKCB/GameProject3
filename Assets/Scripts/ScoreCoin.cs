using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCoin : MonoBehaviour
{
    public GameObject coinObj;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(coinObj);
        }
        
    }
}
