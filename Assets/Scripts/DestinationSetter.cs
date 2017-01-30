

using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class DestinationSetter : MonoBehaviour 
{
    public Camera TheCamera;
	private Transform mCentralMessageTrans;
	private Vector3 mTargetPoint;
    Ray mRay = new Ray();
    RaycastHit mHitInfo = new RaycastHit();
    private Probe mTheSelectedProbe = null;
    private Color mColorBuffer;
    private Transform mMark;
	private CentralMessage mCentralMessage;

	void Start()
	{
		mCentralMessage = FindObjectOfType<CentralMessage> ();
		mCentralMessageTrans = mCentralMessage.transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (Input.GetMouseButtonDown(0))
        {
            UnSelect();
			mRay = TheCamera.ScreenPointToRay(Input.mousePosition);            
			if (Physics.Raycast(mRay, out mHitInfo, 100, 1 << 8))
            {
                Select();
            }
        }
        if (Input.GetMouseButtonDown(1) && mTheSelectedProbe != null)
        {
			mRay = TheCamera.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(mRay, out mHitInfo, 100, 1 << 9))
            {
                mTargetPoint = mHitInfo.point;
                mTheSelectedProbe.SetDestination(mTargetPoint);                
            }
        }
    }

    private void Select()
    {
        mMark = mHitInfo.collider.transform;
        mTheSelectedProbe = mMark.root.GetComponentInParent<Probe>();
        mTheSelectedProbe.mProbeCamera.enabled = true;
        mColorBuffer = mMark.GetComponent<MeshRenderer>().material.GetColor("_Color");
        mMark.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
		mCentralMessageTrans.parent = mTheSelectedProbe.mProbeCamera.transform;
		mCentralMessageTrans.rotation = mTheSelectedProbe.mProbeCamera.transform.rotation;
		mCentralMessageTrans.localPosition = new Vector3 (-19,10,20);
		mCentralMessage.SetProbe (mTheSelectedProbe.NameId);
    }

    private void UnSelect()
    {
        if (mTheSelectedProbe != null)
        {
            mTheSelectedProbe.mProbeCamera.enabled = false;
            mMark.GetComponent<MeshRenderer>().material.SetColor("_Color", mColorBuffer);
            mTheSelectedProbe = null;
			mCentralMessageTrans.parent = null;
			mCentralMessageTrans.localPosition = Vector3.one * 2000;
        }
    }
}
