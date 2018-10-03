using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioPlayer))]
public class AudioRecorder : MonoBehaviour {

    private AudioClip recording;
    private AudioPlayer audioPlayer;

    // Use this for initialization
    void Start ()
    {
        audioPlayer = GetComponent<AudioPlayer>();
	}
	
    public void RecordAudio()
    {
        recording = Microphone.Start(Microphone.devices[0], false, 3, 44100);
    }

    public AudioClip GetRecording()
    {
        return recording;
    }

    public void SetRecording(AudioClip clip)
    {
        recording = clip;
    }

    public void PlayRecording()
    {
        audioPlayer.PlayAudio(recording);
    }
}
