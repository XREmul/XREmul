using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

public class HeadDirectionReplayerEmitter : AbstractHeadDirectionEmitter
{
    public string HeadDirectionLogPath;
    public bool Play;

    private float internalLogTimer_ = 0.0f;

    public override Quaternion HeadDirection
    {
        get
        {
            throw new System.NotImplementedException();
        }
    }

    class HeadDirectionLog
    {
        public float timer;
        public Quaternion rotation;
    }

    private List<HeadDirectionLog> headDirectionLogs_ = new List<HeadDirectionLog>();
    private int headDirectionLogIndex = 0;

    public void Start()
    {
        if (!Play)
            return;

        var path = Path.Combine(Application.dataPath, HeadDirectionLogPath + ".log");

        using (StreamReader reader = new StreamReader(path, Encoding.UTF8))
        {
            headDirectionLogs_ =
                    reader.ReadToEnd()
                        .Split("\n".ToCharArray(), 1)
                        .Select(x =>
                        {
                            string[] splitted = x.Split(",".ToCharArray(), 1);
                            return new HeadDirectionLog
                            {
                                timer = float.Parse(splitted[0]),
                                rotation = Quaternion.Euler(float.Parse(splitted[1]),
                                float.Parse(splitted[2]), float.Parse(splitted[3]))
                            };
                        }).ToList();
        }

        headDirectionLogIndex = 0;
    }

    public void Update()
    {
        internalLogTimer_ += Time.deltaTime;
    }
}
