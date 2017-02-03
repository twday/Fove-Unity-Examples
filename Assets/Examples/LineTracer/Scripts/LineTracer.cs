using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTracer : MonoBehaviour {

    [Tooltip("The eye used to draw")]
    public Fove.EFVR_Eye eye;
    [Tooltip("Distance from user to draw at")]
    public float drawDistance = 3.0f;
    [Tooltip("Color of the line")]
    public Color lineColor = Color.green;
    [Tooltip("Width of the line")]
    public float lineWidth = 1.0f;
    [Tooltip("Minimum movement threshold")]
    public float movementThreshold = 1.0f;

    LineRenderer lineRenderer;
    Vector3 prevPos, currPos;
    List<Vector3> points;

    // Use this for initialization
    void Start () {
        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null)
            lineRenderer = gameObject.AddComponent<LineRenderer>();

        lineRenderer.startColor = lineColor;
        lineRenderer.startWidth = lineWidth;
	}
	
	// Update is called once per frame
	void Update () {
        currPos = Vector3.zero;

        switch (FoveInterface.CheckEyesClosed())
        {
            case Fove.EFVR_Eye.Both:
                break;
            case Fove.EFVR_Eye.Left:
                currPos = FoveInterface.GetEyeRays().left.GetPoint(drawDistance);
                break;
            case Fove.EFVR_Eye.Right:
                currPos = FoveInterface.GetEyeRays().right.GetPoint(drawDistance);
                break;
            case Fove.EFVR_Eye.Neither:
                break;
        }

        if (currPos != Vector3.zero)
        {
            float dist = Vector3.Distance(prevPos, currPos);


            if (dist > movementThreshold)
            {
                points.Add(currPos);

                lineRenderer.numPositions = points.Count;
                for (int i = 0; i < points.Count; i++)
                {
                    lineRenderer.SetPosition(i, points[i]);
                }
            }
        }
	}
}
