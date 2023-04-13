using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   public static AudioManager Instance;
   public AudioSource ButtonClick;
       private void Awake()
       {
           if(Instance == null || Instance == this)
           {
               Instance = this;
               DontDestroyOnLoad(this);
           }
   
           else
           {
               Destroy(this.gameObject);
           }
       }

       public void PlayButtonClick()
       {
           ButtonClick.Play();
       }
       
}
