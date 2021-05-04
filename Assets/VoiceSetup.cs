using UnityEngine;
using Photon.Voice.Unity;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.Android;


public class VoiceSetup : MonoBehaviourPunCallbacks
{

    public Recorder recorder;

    public bool hasMicPermission;
    bool isRequesting;

    bool hasRestartedRecorder = false;

    // Start is called before the first frame update
    void Start()
    {
        recorder = GetComponent<Recorder>();
     
        InitVoiceController();
    }

    public void InitVoiceController()
    {
        if(Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            hasMicPermission = true;
            recorder.RestartRecording();
            hasRestartedRecorder = true;
        }
        else
        {
            Permission.RequestUserPermission(Permission.Microphone);
            isRequesting = true;
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus && isRequesting)
        {
            if (Permission.HasUserAuthorizedPermission(Permission.Microphone))
            {
                hasMicPermission = true;
                recorder.RestartRecording();
                hasRestartedRecorder = true;
            }
            else
            {
                hasMicPermission = false;
            }
            isRequesting = false;
        }
    }

    public void StartRecording()
    {
        if (hasMicPermission)
        {
            recorder.TransmitEnabled = true;
            recorder.StartRecording();
        }
    }

    public void StopRecording()
    {
        if (!hasMicPermission)
        {
            recorder.StopRecording();
            recorder.TransmitEnabled = false;
        }
    }

    private void Update()
    {
        if(recorder == null)
        {
            recorder = GetComponent<Recorder>();
        }

        if(hasMicPermission && recorder.IsRecording == false)
        {
            StartRecording();
        }

        // if (!PlayerSettings.Instance.useVoice)
        // {
        //     GetRecorder().TransmitEnabled = false;
        // }
    }
}