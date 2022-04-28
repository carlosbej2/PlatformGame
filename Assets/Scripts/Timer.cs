using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeValue=90;
    //public float minTime = 0.05f;
    //public float maxTime = 1.2f;
    public Text timerText;
    public GameObject player;
    public AudioSource dyingS;
   

    // Start is called before the first frame update
    void Start()
    {
      //  timerText = GetComponent<Text>();
      //  timeValue = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(timeValue > 0)
        {
            timeValue -= Time.deltaTime;
            //  timerText.enabled = true;
            // timeValue == Random.Range(minTime, maxTime); 
        }else{
            timeValue = 0;
        }
        
        DisplayTime(timeValue);
        
    }

    private IEnumerator WaitForSceneLoad() {
    player.GetComponent<MeshRenderer>().enabled = false;
    player.GetComponent<Rigidbody>().isKinematic = true;
    player.GetComponent<Move>().enabled = false;
    yield return new WaitForSeconds(2);
    SceneManager.LoadScene("GameOver");

 }

     

    void DisplayTime(float timeToDisplay)
    {

        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
            dyingS.Play();
            StartCoroutine(WaitForSceneLoad());
           // Invoke(SceneManager.LoadScene("GameOver"), 2f));
            
        }
        if(timeToDisplay <= 30f){
            timerText.color = Color.red;
          
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float miliseconds = timeToDisplay % 1 * 1000;

        timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, miliseconds);
    }

}
