using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] float Xspeed;
    [SerializeField] float Yspeed;
    [SerializeField] float Zspeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(360 * Xspeed * Time.deltaTime, 
                                    360 * Yspeed * Time.deltaTime,
                                    360 * Zspeed * Time.deltaTime);
    }
}
