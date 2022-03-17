using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toy
{
   // ENCAPSULATION” 
   public Color color { get; set; }
   public string toyName { get; set; }
   public AudioClip toySound { get; set; }
   public AudioSource toyAS { get; set; }



    public Toy(Color color, string name)
    {

    }

    public virtual void Move()
    {

    }

    public virtual void MakeSound(AudioSource source, AudioClip clip)
    {
        toyAS = source;
        toySound = clip;
        toyAS.PlayOneShot(clip);
    }


}
