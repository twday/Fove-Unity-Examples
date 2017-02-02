using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DetectBlink : MonoBehaviour {

    [Tooltip("Threshold for blink in seconds \n(Average is between 0.3 and 0.4 seconds)")]
    public float blinkThreshold = 0.5f;
    [Tooltip("Check if you want output to debug objects")]
    public bool debug = false;

    /* Timer Struct */
    struct Timer
    {
        public float value { get; set; }
        public bool started { get; set; }
    }

    Timer t;

	// Use this for initialization
	void Start () {
        t = new Timer();
	}
	
	// Update is called once per frame
	void Update () {

        if (FoveInterface.CheckEyesClosed() == Fove.EFVR_Eye.Both)
            t.started = true;

        if (t.started) t.value += Time.deltaTime;

        if (FoveInterface.CheckEyesClosed() == Fove.EFVR_Eye.Neither && t.started)
        {

            if (t.value < blinkThreshold)
            {
                if (debug) Debug.Log("Blink Detected");
            }

            t.started = false;
            t.value = 0;
        }
	}
}