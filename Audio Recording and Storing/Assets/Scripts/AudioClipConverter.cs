using UnityEngine;

public class AudioClipConverter
{	
    public RecordingData ConvertAudioClipToData(AudioClip audioClip)
    {
        RecordingData data = new RecordingData();
        
        float[] samples = new float[audioClip.samples];
        audioClip.GetData(samples, 0);
        data.AudioSamples = samples;

        data.RecordingName = audioClip.name;
        data.Frequency = audioClip.frequency;
        data.Channels = audioClip.channels;

        return data;
    }

    public AudioClip ConvertDataToAudioClip(RecordingData data)
    {
        AudioClip audioClip = AudioClip.Create(data.RecordingName, data.AudioSamples.Length, data.Channels, data.Frequency, false);
        audioClip.SetData(data.AudioSamples, 0);
        return audioClip;
    }
}
