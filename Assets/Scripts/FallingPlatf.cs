using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatf : MonoBehaviour
{

    bool alreadyFalling = false;
    [SerializeField] private float tiempoReaparecer;
    float downwardsForce = 0;
    private Vector3 startPosition;

    void OnTriggerEnter(Collider collider){
        if (collider.gameObject.name == "Player"){
            alreadyFalling = true;
            //Destroy(gameObject, 10);
            Invoke("SpawnPlatform", tiempoReaparecer);

            
        }
    }

    void Start(){

    startPosition = transform.position;

    }

    private void SpawnPlatform(){

alreadyFalling = false;
transform.position = startPosition;
downwardsForce = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (alreadyFalling){

            downwardsForce += Time.deltaTime/80;
            transform.position = new Vector3(transform.position.x,
                                             transform.position.y-downwardsForce,
                                             transform.position.z);

        }


    }
}
