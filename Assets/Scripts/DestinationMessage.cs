using UnityEngine;
using System.Collections;
using System;

public class DestinationMessage : AMessage
{
    internal Vector3 StartPoint;
    internal Vector3 Destination;
     internal new void AddContent(sMessageContent mMessageContent)
    {
        base.AddContent(mMessageContent);
        StartPoint = mMessageContent.mPosition;
        Destination = mMessageContent.mDestination;
        mMessageType = eMessageType.Destination;
    }
}
