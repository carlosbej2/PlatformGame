using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatf : MonoBehaviour
{

    bool alreadyFalling = false;
    float downwardsForce = 0;

    void OnTriggerEnter(Collider collider){
        if (collider.gameObject.name == "Player"){
            alreadyFalling = true;
            //Destroy(gameObject, 10);
        }
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
