using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collector : MonoBehaviour
{
    int coinsCollected = 0;

    [SerializeField] Text coinsCollectedText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CoinCollectable")){
            Destroy(other.gameObject);
            coinsCollected++;
            coinsCollectedText.text = "Coins collected: " + coinsCollected;

        }
    }    
}
