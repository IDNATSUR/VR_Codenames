using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using Photon.Pun;
using Photon.Realtime;
using Photon.Voice.Unity;
using Photon.Voice.PUN;

public class microphone_setup : MonoBehaviourPun
{
    // Start is called before the first frame update
    AudioSource audiosource;
    private string microphone;
    public Recorder VoiceRecorder;
    void Start()
    {
        if (Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            // The user authorized use of the microphone.
            Debug.Log("authorized: ");
        }
        else
        {
            // We do not have permission to use the microphone.
            // Ask for permission or proceed without the functionality enabled.
            Debug.Log("not authorized: ");
            Permission.RequestUserPermission(Permission.Microphone);

        }
    	audiosource=GetComponent<AudioSource>();
    	foreach(string device in UnityEngine.Microphone.devices){
    		if(microphone==null){
    			microphone=device;
    			break;
    		}
    	}
        
        VoiceRecorder.TransmitEnabled=true;
        //VoiceRecorder.DebugEcho=true;
        audiosource.clip=Microphone.Start(microphone,true,10,44100);
        audiosource.loop=true;
        audiosource.mute=false;
        
    	updateMicrophone();
        
    }

    void updateMicrophone(){
        
        if(Microphone.IsRecording(microphone)){
            while(!(Microphone.GetPosition(microphone)>0)){

            }
            Debug.Log("Audio started in mic: "+ microphone);
            audiosource.Play();
        
    	}
    	else{
    		Debug.Log("Audio not started");

    	}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
