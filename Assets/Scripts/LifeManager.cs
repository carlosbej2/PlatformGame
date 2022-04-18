using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
    public GameObject explosion;

    private void OnCollisionEnter(Collision collision){

        if (collision.gameObject.CompareTag("Enemy")){
            YouDie();
        }
    }

    void YouDie(){

        Instantiate(explosion, transform.position, Quaternion.identity);
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Move>().enabled = false;
        Invoke(nameof(ReloadLvl), 2f);
    }

    void ReloadLvl(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Update(){
        if (transform.position.y < -5f){
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Move>().enabled = false;
            Invoke(nameof(ReloadLvl), 1f);
        }
    }
    
        
    }

