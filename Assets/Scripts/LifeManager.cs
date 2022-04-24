using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
    public GameObject explosion;
    public Vector3 startPosition;
    public GameObject[] hearts;
    bool is_dead = false;

    [SerializeField] AudioSource ExplodedS;
    public int number_of_lifes = 2;

    private void Start(){

    }


    private void OnCollisionEnter(Collision collision){

        if (collision.gameObject.CompareTag("Enemy")){
            YouDie();
        }
    }

    void YouDie(){

        Instantiate(explosion, transform.position, Quaternion.identity);
        ExplodedS.Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Move>().enabled = false;
        is_dead = true;
        TakeDamage(1);
        Invoke(nameof(ReloadLvl), 2f);

        
    }


     public void TakeDamage(int d){
        if (number_of_lifes == 3 && is_dead){
            Destroy(hearts[0].gameObject);
            number_of_lifes--;
            is_dead = false;
        }else if(number_of_lifes == 2 && is_dead){
            Destroy(hearts[2].gameObject);
            number_of_lifes--;
            is_dead = false;
        }else if(number_of_lifes == 1 && is_dead){
            Destroy(hearts[1].gameObject);
            number_of_lifes--;
            is_dead = false;
        } else if(number_of_lifes == 0 && is_dead){
            DeadEnd();
    }
     }
       //Vector3(0,1.25,-8.75)
    void ReloadLvl(){
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Move>().enabled = true;
        TakeDamage(1);
        transform.position = startPosition;
       // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Awake(){

        startPosition = transform.position;
    }

    void DeadEnd(){
// de momento te saca al menu principal
        SceneManager.LoadScene(5);
    }

    public void Update(){
        if (transform.position.y < -5f){
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Move>().enabled = false;
            Invoke(nameof(ReloadLvl), 1f);
            is_dead = true;
        }
  
    }
    
        
    }

