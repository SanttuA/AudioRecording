
//Holds data for an array of recordings
[System.Serializable]
public class RecordingDataSet
{
    public RecordingData[] RecordingDataArray { get; set; }
}

//Holds data for single recording
[System.Serializable]
public class RecordingData
{
    public float[] AudioSamples { get; set; }
    public string RecordingName { get; set; }
    public int Frequency { get; set; }
    public int Channels { get; set; }
}