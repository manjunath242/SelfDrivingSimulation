using UnityEngine;
using System.Collections;

public class AICar : MonoBehaviour {
    public float zLane1;
    public float zLane2;
    public float zLane3;
    float triggerLaneChange;
    private Vector3 targetPos;
    public float laneChangeSpeed;
    int RandomLaneSelector;
    float selectedLane;
    bool ChangeAgain = false;
    float flashingTime = 0.4f;

    //z increases while going left
    public Light LeftIndicator;
    public Light RightIndicator;

    // Use this for initialization
    void Start () {
        triggerLaneChange = Random.Range(2.0f, 5.0f);
        targetPos = transform.position;
        targetPos.z = SelectLane();

        LeftIndicator.enabled = false;
        RightIndicator.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        triggerLaneChange = triggerLaneChange - Time.deltaTime;

        if (targetPos.z == transform.position.z)
        {
            LeftIndicator.enabled = false;
            RightIndicator.enabled = false;
            ChangeAgain = true;
        }
        else {
            if (triggerLaneChange < 1.5)
            {

                FlashIndicator();
                if (triggerLaneChange < 0)
                {
                   // Debug.Log("Changing lane now");
                    var step = laneChangeSpeed * Time.deltaTime;
                    transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
                    if (transform.position == targetPos)
                    {
                        ChangeAgain = true;
                    }
                }

            }
        }

        if (ChangeAgain)
        {
            triggerLaneChange = Random.Range(2.0f, 5.0f);
            targetPos.z = SelectLane();
        }

    }

    void FlashIndicator()
    {
        bool leftIndiactor=false;
        bool rightIndicator = false;

        if (targetPos.z > transform.position.z)
        {
            leftIndiactor = true;
            rightIndicator = false;
        }
        else if (targetPos.z < transform.position.z)
        {
            leftIndiactor = false;
            rightIndicator = true;
        }

        if (transform.position.z != targetPos.z)
        {
            flashingTime = flashingTime - Time.deltaTime;
            if (flashingTime < 0)
            {
                if (leftIndiactor)
                {
                    LeftIndicator.enabled = true;
                }

                if (rightIndicator)
                {
                    RightIndicator.enabled = true;
                }
               
                flashingTime = 0.2f;
            }
            else
            {
                if (leftIndiactor)
                {
                    LeftIndicator.enabled = false;
                }

                if (rightIndicator)
                {
                    RightIndicator.enabled = false;
                }
            }
        }
    }

    float SelectLane()
    {
        RandomLaneSelector = Random.Range(1, 3);

        if (RandomLaneSelector == 1)
        {
            selectedLane = zLane1;
        }

        if (RandomLaneSelector == 2)
        {
            selectedLane = zLane2;
        }

        if (RandomLaneSelector == 3)
        {
            selectedLane = zLane3;
        }
        ChangeAgain = false;
        return selectedLane;
    }
}
