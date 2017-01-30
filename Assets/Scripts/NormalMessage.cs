using UnityEngine;
using System.Collections;

public class NormalMessage : AMessage 
{
    internal Vector3 Direction;
    internal Vector3 Speed;
    internal Vector3 Position;
    internal new void AddContent(sMessageContent mMessageContent)
    {
        base.AddContent(mMessageContent);
        Direction = mMessageContent.mDirection;
        Speed = mMessageContent.mSpeed;
        Position = mMessageContent.mPosition;
        mMessageType = eMessageType.Normal;
    }
}
