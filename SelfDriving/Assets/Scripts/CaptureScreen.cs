using UnityEngine;
using System.Collections;

public class CaptureScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Application.CaptureScreenshot("Screenshot.png");
        }
    }
}
