using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Central : MonoBehaviour 
{
    private Dictionary<int, SimulatedProbe> mSimulatedProbeList = new Dictionary<int, SimulatedProbe>();
    private SimulatedProbe mSimulatedProbe;
    private float SpaceTime; 
	private CentralMessage mCentralMessage;

    // Use this for initialization
    void Start () 
	{
        foreach (SimulatedProbe sp in FindObjectsOfType<SimulatedProbe>())
        {
            mSimulatedProbeList.Add(sp.NameId,sp);
        }
        InvokeRepeating("PredictPos", 0, 0.5f);
		mCentralMessage = FindObjectOfType<CentralMessage> ();
	}

    internal void TraiteDestinationMessage(DestinationMessage destinationMessage)
    {
		mSimulatedProbe = mSimulatedProbeList [destinationMessage.mNameId];
		if (mSimulatedProbe.mTimeStamp < destinationMessage.mTimeStamp) 
		{			
			mSimulatedProbe.mDestination = destinationMessage.Destination;
			mSimulatedProbe.mDirection = destinationMessage.Destination - destinationMessage.StartPoint;
			mSimulatedProbe.mPosition = destinationMessage.StartPoint;
			mSimulatedProbe.mSpeed = Vector3.zero;
			mSimulatedProbe.mTimeStamp = destinationMessage.mTimeStamp;
		}
    }

	internal void TraiteNormalMessage(NormalMessage normalMessage)
	{
		mSimulatedProbe = mSimulatedProbeList [normalMessage.mNameId];
		if (mSimulatedProbe.mTimeStamp < normalMessage.mTimeStamp) 
		{			
			mSimulatedProbe.mDirection = normalMessage.Direction;
			mSimulatedProbe.mPosition = normalMessage.Position;
			mSimulatedProbe.mSpeed = normalMessage.Speed;
			mSimulatedProbe.mTimeStamp = normalMessage.mTimeStamp;
		}
	}

	internal void TraiteRotationMessage(RotationMessage rotationMessage)
	{
		mSimulatedProbe = mSimulatedProbeList [rotationMessage.mNameId];
		if (mSimulatedProbe.mTimeStamp < rotationMessage.mTimeStamp) 
		{			
			mSimulatedProbe.mDirection = rotationMessage.Direction;
			mSimulatedProbe.mPosition = rotationMessage.Position;
			mSimulatedProbe.mSpeed = rotationMessage.Speed;
			mSimulatedProbe.mTimeStamp = rotationMessage.mTimeStamp;
		}
	}

    private void PredictPos()
    {
        SpaceTime = Time.time;
        foreach (KeyValuePair<int, SimulatedProbe> kvp in mSimulatedProbeList)
        {
			kvp.Value.mPredictedPos = kvp.Value.mPosition + (SpaceTime - kvp.Value.mTimeStamp) * kvp.Value.mSpeed;
			kvp.Value.transform.position = kvp.Value.mPredictedPos;
			if (mCentralMessage.mSimulatedProbe && kvp.Value == mCentralMessage.mSimulatedProbe) 
			{
				mCentralMessage.ShowMessage ();
			}
        }
    }
}
