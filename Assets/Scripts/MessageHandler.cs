using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class MessageHandler : MonoBehaviour 
{
    private float mSpacetime;

    internal List<AMessage> InSpaceMessages = new List<AMessage>();
    internal List<AMessage> ArrivalMessages = new List<AMessage>();

    private Central mCentral;

    void Start()
    {
        mCentral = FindObjectOfType<Central>();
    }

    // Update is called once per frame
    void Update ()
    {
        mSpacetime = Time.time;
        WaitMessage();
        SendMessageToCentral();
    }

    private void SendMessageToCentral()
    {
        for (int i = 0; i < ArrivalMessages.Count; ++i)
        {
            switch (ArrivalMessages[i].mMessageType)
            {
                case AMessage.eMessageType.Destination:
                    {
                        mCentral.TraiteDestinationMessage((DestinationMessage)ArrivalMessages[i]);
                    }
                    break;

                case AMessage.eMessageType.Normal:
                    {
						mCentral.TraiteNormalMessage((NormalMessage)ArrivalMessages[i]);
                    }
                    break;
			case AMessage.eMessageType.Rotation:
				{
					mCentral.TraiteRotationMessage((RotationMessage)ArrivalMessages[i]);
				}
				break;
            }
            ArrivalMessages.Remove(ArrivalMessages[i]);
        }
    }

    private void WaitMessage()
    {
        for (int i = 0; i < InSpaceMessages.Count; ++i)
        {
            if (mSpacetime - InSpaceMessages[i].mTimeStamp >= 2)
            {
                ArrivalMessages.Add(InSpaceMessages[i]);
                InSpaceMessages.Remove(InSpaceMessages[i]);
            }
        }
    }
}
