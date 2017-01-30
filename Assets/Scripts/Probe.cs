using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System;

public class Probe : MonoBehaviour 
{

    public int NameId;
    internal float mSpeed;
    internal Quaternion mRotation;
    internal float mAngle;

    internal Camera mProbeCamera;
    private AMessage.sMessageContent mMessageContent = new AMessage.sMessageContent();
    private NavMeshAgent mNma;
    private DestinationMessage mDestinationMessage = new DestinationMessage();
    private NormalMessage mNormalMessage = new NormalMessage();
	private RotationMessage mRotationMessage = new RotationMessage();
    private MessageHandler mSpace;
	private CarVibration mCarVibration;

	// Use this for initialization
	void Start () 
	{
        mProbeCamera = GetComponentInChildren<Camera>();
        mProbeCamera.enabled = false;
        mNma = GetComponent<NavMeshAgent>();
        mSpace = FindObjectOfType<MessageHandler>();
        InvokeRepeating("SendNormalMessage", 0, 1);
		mCarVibration = GetComponentInChildren<CarVibration> ();
        mRotation = transform.rotation;
		mMessageContent.mNameId = NameId;
		transform.FindChild ("Mark").GetComponent<MeshRenderer> ().enabled = true;
    }
	
	// Update is called once per frame
	void Update () 
	{        
		Move ();
		if (mRotation != transform.rotation) 
		{
			mAngle = Quaternion.Angle (mRotation, transform.rotation);
			SendRotationMessage ();
			mRotation = transform.rotation;
		}
    }

	private void Move()
	{
		mSpeed = mNma.velocity.magnitude;
		if (mSpeed > 0.01f) 
		{
			mCarVibration.enabled = true;
		} else 
		{
			mCarVibration.enabled = false;
		}
	}

    internal void SetDestination(Vector3 targetPoint)
    {
		mMessageContent.mTimeStamp = Time.time;
        UpdateMessageContent();
        mMessageContent.mDestination = targetPoint;
        mNma.SetDestination(targetPoint);
        mDestinationMessage = new DestinationMessage();
        mDestinationMessage.AddContent(mMessageContent);
        SendMessage(mDestinationMessage);
    }

    private void UpdateMessageContent()
    {
        mMessageContent.mTimeStamp = Time.time;
        mMessageContent.mPosition = transform.position;
        mMessageContent.mSpeed = mNma.velocity;
		mMessageContent.mDirection = transform.forward;
    }

    private void SendNormalMessage()
    {
        UpdateMessageContent();
        mNormalMessage = new NormalMessage();
        mNormalMessage.AddContent(mMessageContent);
        SendMessage(mNormalMessage);
    }

	private void SendRotationMessage()
	{
		UpdateMessageContent();
		mRotationMessage = new RotationMessage();
		mRotationMessage.AddContent(mMessageContent, mAngle);
		SendMessage(mRotationMessage);
	}

    private void SendMessage(AMessage mMessage)
    {
        mSpace.InSpaceMessages.Add(mMessage);
    }
}
