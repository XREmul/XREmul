using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoveHeadDirectionEmitter : AbstractHeadDirectionEmitter {
    public override Quaternion HeadDirection
    {
        get
        {
            return FoveInterface.GetHMDRotation();
        }
    }
}
