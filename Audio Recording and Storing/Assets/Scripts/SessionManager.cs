using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioRecorder))]
public class SessionManager : MonoBehaviour {

    private AudioRecorder audioRecorder;

    [SerializeField]
    private string recordingFileName = "myRecordingData.dat";

    private DataStorageHandler<RecordingData> dataStorageHandler;
    private AudioClipConverter audioClipConverter;

	// Use this for initialization
	void Start ()
    {
        audioRecorder = GetComponent<AudioRecorder>();

        dataStorageHandler = new DataStorageHandler<RecordingData>();
        audioClipConverter = new AudioClipConverter();
    }
	
    public void SaveRecording()
    {
        if(dataStorageHandler == null)
            dataStorageHandler = new DataStorageHandler<RecordingData>();

        if(audioClipConverter == null)
            audioClipConverter = new AudioClipConverter();

        RecordingData data = audioClipConverter.ConvertAudioClipToData(audioRecorder.GetRecording());
        dataStorageHandler.SaveData(data, recordingFileName);
    }

    public void LoadRecording()
    {
        if (dataStorageHandler == null)
            dataStorageHandler = new DataStorageHandler<RecordingData>();

        if (audioClipConverter == null)
            audioClipConverter = new AudioClipConverter();

        RecordingData data = dataStorageHandler.LoadData(recordingFileName);
        AudioClip clip = audioClipConverter.ConvertDataToAudioClip(data);

        audioRecorder.SetRecording(clip);
    }
}
