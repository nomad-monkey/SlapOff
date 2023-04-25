using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedCalculator : MonoBehaviour
{
    private Vector3 _oldPosition;

    private void Start()
    {
        _oldPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var position = transform.position;
        var speed = (position - _oldPosition).magnitude / Time.deltaTime;
        _oldPosition = position;
        Debug.Log("Speed: " + speed.ToString("F0"));
    }
}
