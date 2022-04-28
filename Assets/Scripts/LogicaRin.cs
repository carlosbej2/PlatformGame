using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaRin : MonoBehaviour
{

    public float velocidad;
    public float velocidadRotacion;

    float x, y;
    // Start is called before the first frame update
    void Start()
    {

    
        
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velocidadRotacion);
        
    }
}
