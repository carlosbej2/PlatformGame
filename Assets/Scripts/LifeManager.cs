using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
    public GameObject explosion;
    public GameObject[] hearts;

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
        Invoke(nameof(ReloadLvl), 2f);

        
    }

//falta terminarlo, el problema de esto es que en el momento en el Update() se reinicia el nivel,
//tambien se reinician las vidas... en vez de reiniciar el nivel, lo que deberiamos hacer
//seria que hiciera respawn en un sitio. esto es facil pero son 2am y estoy exhausto, 
//mañana lo gestionamos
     public void TakeDamage(int d){
        if (number_of_lifes == 3){
            Destroy(hearts[0].gameObject);
            number_of_lifes--;
        }else if(number_of_lifes == 2){
            Destroy(hearts[2].gameObject);
            number_of_lifes--;
        }else if(number_of_lifes == 1){
            Destroy(hearts[1].gameObject);
            Debug.Log("DEAD");
        }
    }

    void ReloadLvl(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void DeadEnd(){
// de momento te saca al menu principal
        SceneManager.LoadScene(0);
    }

    public void Update(){
        if (transform.position.y < -5f){
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Move>().enabled = false;
            Invoke(nameof(ReloadLvl), 1f);
        }
  
    }
    
        
    }

