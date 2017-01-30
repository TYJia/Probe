//作者：贾天源
//作用：载具震动
//规范检查：贾天源 20161206

using UnityEngine;
using System.Collections;

public class CarVibration : MonoBehaviour
{

    private Vector3 mY;
    private float[] mTimeScales;
    private float[] mAmplitude;
    private float mMax = 0;

    // Use this for initialization
    void Awake()
    {

        mTimeScales = new float[10];
        mAmplitude = new float[10];

        for (int i = 0; i < mTimeScales.Length; i++)
        {
            mTimeScales[i] = Random.Range(2f, 14f);
            mAmplitude[i] = Random.Range(0.001f, 0.005f);
            mMax = mMax + mAmplitude[i];
        }

    }

    // Update is called once per frame
    void Update()
    {

        float triangleSum = 0;

        for (int i = 0; i < mTimeScales.Length; i++)
        {
            triangleSum = Mathf.Sin(Time.time * mTimeScales[i]) * mAmplitude[i] + triangleSum;
        }

        mY = transform.localPosition;
        mY.Set(mY.x, triangleSum, mY.z);
        transform.localPosition = mY;


    }
}
