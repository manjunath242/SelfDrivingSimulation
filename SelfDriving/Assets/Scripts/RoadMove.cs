using UnityEngine;
using System.Collections;

public class RoadMove : MonoBehaviour {

    public float reachpoint = 0f;
    Vector3 NewPosition;
    public float thrust;
    public Rigidbody rb;
    public GameObject OtherRoad;
    public GameObject AutonomousCar;
    public bool isFirst;
    public bool SpecificLogger;
    public float RelocationX;

    // Use this for initialization
    void Start () {
        Debug.Log(OtherRoad.transform.position + " " + this.transform.position);
        NewPosition = this.transform.position;
        rb = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        rb.AddForce(transform.right * -thrust);
    }

    // Update is called once per frame
    void Update () {
        //rb.AddForce(transform.forward * thrust);
        if (SpecificLogger)
        {
            Debug.Log(NewPosition.x);
        }
    }

    void OnTriggerEnter(Collider other)
    {
      

        if ((other.gameObject == AutonomousCar)&&(!isFirst))
        {
            NewPosition.x = RelocationX;
            OtherRoad.transform.position = NewPosition;
        }
        isFirst = false;

    }
}
