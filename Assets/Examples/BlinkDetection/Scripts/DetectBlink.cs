using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectBlink : MonoBehaviour {

    [Tooltip("Threshold for blink in seconds \n(Average is between 0.3 and 0.4 seconds)")]
    public float blinkThreshold = 0.5f;
    [Tooltip("Light controlled by blinking")]
    public Light blinkLight;

    /// <summary>
    ///     Timer Construct
    ///     <param name="value">Holds the value of the timer</param>
    ///     <param name="started">Is the timer started?</param>
    /// </summary>
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

        /*
         * If eyes have been closed, start the timer
         */
        if (FoveInterface.CheckEyesClosed() == Fove.EFVR_Eye.Both)
            t.started = true;

        if (t.started) t.value += Time.deltaTime;

        if (FoveInterface.CheckEyesClosed() == Fove.EFVR_Eye.Neither && t.started)
        {
            /*
             * If time between closing and opening eyes is less than the threshold
             * A blink has been detected
             */
            if (t.value < blinkThreshold)
            {
                blinkLight.enabled = !blinkLight.enabled;
            }

            t.started = false;
            t.value = 0;
        }
	}
}
