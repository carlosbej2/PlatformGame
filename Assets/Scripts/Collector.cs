using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Collector : MonoBehaviour
{
    int coinsCollected = 0;
    bool hasAllCoins = false;
    private Scene scene;

   /* void Start()
    {
        scene = SceneManager.GetActiveScene().name;
    }
   */
    [SerializeField] Text coinsCollectedText;
    [SerializeField] AudioSource coinCollectedS;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CoinCollectable")){
            Destroy(other.gameObject);
            coinCollectedS.Play();
            coinsCollected++;
            coinsCollectedText.text = "Coins collected: " + coinsCollected;

            if(coinsCollected==5){
                hasAllCoins = true;
                Debug.Log("TODAS MONDEPAS");
            }
            
        }

    
    }

    void Update(){

        if(hasAllCoins && SceneManager.GetActiveScene().name=="Level1"){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            hasAllCoins = false;
        }
    }

   

}
