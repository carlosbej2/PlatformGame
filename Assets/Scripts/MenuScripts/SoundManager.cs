using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{

    Image soundOnIcon;
    Image soundOffIcon;
    [SerializeField] Slider volumeSlider;
    private bool muted = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }

//de momento se queda asi, lo que tenemos que hacer es que lo de mutear solo sea
//un boton, que cuando le cliques cambie la imagen por el mismo boton pero con una raya
//roja en el centro. 
    public void OnButtonPress()
    {
        if(muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }else{
            muted = false;
            AudioListener.pause = false;
        }

        
    }

    
}
