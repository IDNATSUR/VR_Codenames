
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{

	public Sound[] sounds;
    
    void Start()
    {
        foreach(Sound s in sounds){
        	s.source=gameObject.AddComponent<AudioSource>();
        	s.source.clip = s.clip;

        	s.source.volume=s.volume;
        	s.source.pitch =s.pitch;

        }
    }

    public void Play(string name)
    {
        Sound s=Array.Find(sounds,sound=>sound.name==name);
        if(s==null)
        	return;

        //s.source.PlayOneShot(s.source.clip,0.5f);
        s.source.Play();
        for(int i=0;i<10000000;i++){
            
        }
        s.source.Stop ();
    }
}
