using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakePower;
    [SerializeField] float shakeFrequent;
    [SerializeField] float shakeTime;
    public static CameraShake cameraShake;
    private CinemachineBasicMultiChannelPerlin _CBMCP;
    // Start is called before the first frame update
    private void Awake() 
    {
        _CBMCP = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cameraShake = GetComponent<CameraShake>();
    }
        
    public void ShakeCamera()
    {
        _CBMCP.m_AmplitudeGain = shakePower;
        _CBMCP.m_FrequencyGain = shakeFrequent;
        StartCoroutine(StopShake());
    }

    IEnumerator StopShake()
    {
        yield return new WaitForSeconds(shakeTime);
        _CBMCP.m_AmplitudeGain = 0;
        _CBMCP.m_FrequencyGain = 0;
    }
}
