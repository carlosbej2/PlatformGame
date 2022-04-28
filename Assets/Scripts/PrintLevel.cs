using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PrintLevel : MonoBehaviour
{
    string frase1 = "Level 1: enjoy the level!!";
    string frase2 = "Level 2: now it gets serious...";
    string frase3 = "Level 3: 'Genius is one percent inspiration and ninety-nine percent effort'... find the easter eggs! ";
    string gameOver = "G A M E   O V E R ";
    string thx = "Thanks for playing :)";
    public Text texto;

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Level1"){

              StartCoroutine(PintarNivel1());
        }

        if(SceneManager.GetActiveScene().name == "Level2"){

              StartCoroutine(PintarNivel2());
        }

        if(SceneManager.GetActiveScene().name == "Level 3"){

              StartCoroutine(PintarNivel3());
        }

        if(SceneManager.GetActiveScene().name == "GameOver"){

              StartCoroutine(PintarGameOver());
        }
 
    }


    IEnumerator PintarNivel1()
    {
        foreach (char caracter in frase1)
        {
            texto.text = texto.text + caracter;
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(gameObject, 2.0f);

    }

    IEnumerator PintarNivel2()
    {
        foreach (char caracter in frase2)
        {
            texto.text = texto.text + caracter;
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(gameObject, 2.0f);

    }

    IEnumerator PintarNivel3()
    {
        foreach (char caracter in frase3)
        {
            texto.text = texto.text + caracter;
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(gameObject, 2.0f);

    }

    IEnumerator PintarGameOver()
    {
        
        foreach (char caracter in gameOver)
        {
            texto.text = texto.text + caracter;
            yield return new WaitForSeconds(0.1f);
        } 

        foreach (char caracter in thx)
        {
            texto.text = texto.text + caracter;
            yield return new WaitForSeconds(0.1f);
        } 

     

    }

}