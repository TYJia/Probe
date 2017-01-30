using UnityEngine;
using System.Collections;

public class SimulatedProbe : MonoBehaviour 
{
    public int NameId;
    internal Vector3 mDestination;
    internal Vector3 mSpeed;
    internal Vector3 mDirection;
	internal Vector3 mPosition = Vector3.one * 2000;
	internal Vector3 mPredictedPos;
    internal float mTimeStamp;

	void Awake()
	{
		GetComponent<MeshRenderer> ().enabled = true;
	}
}
