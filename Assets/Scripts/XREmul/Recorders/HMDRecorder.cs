using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class HMDRecorder : MonoBehaviour {
    public bool IsRecording = false;

    private float timer_ = 0.0f;

    class RotationLog
    {
        public float Timer;
        public Quaternion Rotation;

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4}",
                Timer, Rotation.x, Rotation.y, Rotation.z, Rotation.z);
        }
    }

    private List<RotationLog> rotationLogs_ = new List<RotationLog>();
    
	void Update()
    {
        if (!IsRecording)
            return;

        rotationLogs_.Add(new RotationLog
        {
            Timer = timer_,
            Rotation = transform.rotation
        });

        timer_ += Time.deltaTime;
    }

    public void Dump(string path)
    {
        using (StreamWriter writer = new StreamWriter(path, true))
        {
            foreach (RotationLog log in rotationLogs_)
            {
                writer.WriteLine(log.ToString());
            }

            rotationLogs_.Clear();
        }
    }
}
