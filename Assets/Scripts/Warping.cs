using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warping : MonoBehaviour
{

    public Transform warpDestiny;
    public GameObject player;
    public AudioSource warpingSound;


    void OnTriggerEnter(Collider other){
        warpingSound.Play();
        player.transform.position = warpDestiny.transform.position;
    }
}
