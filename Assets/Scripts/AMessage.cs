using UnityEngine;
using System.Collections;

public class AMessage 
{
    internal struct sMessageContent
    {
        internal int mNameId;
        internal Vector3 mDestination;
        internal Vector3 mSpeed;
        internal Vector3 mDirection;
        internal Vector3 mPosition;
        internal float mTimeStamp;        
    }

    internal enum eMessageState
    {
        InSpace = 0,
        Arrival = 1,
        Traited = 2
    };

    internal enum eMessageType
    {
        Destination = 0,
        Rotation = 1,
        Normal = 2
    };

    internal int mNameId;
    internal float mTimeStamp;
    internal eMessageState mArrivalState;
    internal eMessageType mMessageType;

    internal void AddContent(sMessageContent messageContent)
    {
        mNameId = messageContent.mNameId;
        mTimeStamp = messageContent.mTimeStamp;
        mArrivalState = eMessageState.InSpace;
    }
}
