using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;
using TMPro;

public class HeadsetTracker : MonoBehaviour
{
    public TMP_Text velocityText;
    public TMP_Text rangeText;
    private InputDevice headsetDevice;
    private Vector3 lastpos;
    private Vector3 currentVelocity;
    private float totalRangeOfMotion = 0f;

    

    void Start()
    {
        headsetDevice = InputDevices.GetDeviceAtXRNode(XRNode.Head);
        lastpos = Vector3.zero;
        
    }

    
    void Update()
    {
        Vector3 currentPosition;
        if (headsetDevice.TryGetFeatureValue(CommonUsages.devicePosition, out currentPosition))
        {
            currentVelocity = (currentPosition - lastpos) / Time.deltaTime; //actively getting velocity
            totalRangeOfMotion += Vector3.Distance(currentPosition, lastpos); //getting total range of motion CHANGE
            lastpos = currentPosition; //store last position

//STORING DATA ON UI
            velocityText.text = "Velocity: " + currentVelocity.magnitude.ToString("F2") + " m/s"; 
            rangeText.text = "Range of Motion: " + totalRangeOfMotion.ToString("F2") + " meters";
        }
    }
    }

