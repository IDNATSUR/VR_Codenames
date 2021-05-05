using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using Photon.Pun;
using Photon.Realtime;
using Photon.Voice.Unity;
using Photon.Voice.PUN;


public class MicrophoneTest : MonoBehaviour 
{
    GameObject dialog = null;
    AudioSource audiosource;
    private string microphone=null;
    public Recorder VoiceRecorder;

    void Start ()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
            dialog = new GameObject();
        }
        
        Debug.Log("This is 1st log for mic");

        //updateMicrophone();
    }

    void updateMicrophone(){
        //VoiceRecorder.DebugEcho=true;
        Debug.Log("This is inside updateMicrophone log for mic");
        
        audiosource=GetComponent<AudioSource>();
        foreach(string device in UnityEngine.Microphone.devices){
            if(microphone==null){
                microphone=device;
                break;
            }
        }
        
        VoiceRecorder.TransmitEnabled=true;
        Debug.Log("Microphone update");
        audiosource.clip=Microphone.Start(microphone,true,10,44100);
        audiosource.loop=true;
        audiosource.mute=false;
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
    void OnGUI ()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            dialog.AddComponent<PermissionsRationaleDialog>();
            return;
        }
        else if (dialog != null)
        {
            Destroy(dialog);
        }
        Debug.Log("This is onGUI log for mic");
        
        //updateMicrophone();
        // Now you can do things with the microphone
    }
    void Update()
    {
        Debug.Log("This is update log for mic");
        
        VoiceRecorder.TransmitEnabled=true;
        if(microphone==null)
            updateMicrophone();
    }
}