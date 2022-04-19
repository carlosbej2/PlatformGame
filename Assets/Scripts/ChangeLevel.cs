using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other){

        if(other.gameObject.name == "Player")
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
            //accedemos a File -> Build Setting y tenemos las escenas de nuestro juego y el número de cada una
            //por lo que cada vez que se llame a esta funcion, pasaremos al siguiente nivel solo diciendole a unity que cargue la siguiente escena en el indice
            //de escenas, osea que nunca se va a repetir la misma
        }
    }
}
