 using UnityEngine;
 using System.Collections;
 
 public class carMove : MonoBehaviour {
     
     float xspeep = 0f;
     float power = 0.01f;
     float friction = 0.95f;
     bool front = false;
     bool back = false;
    bool left = false;
    bool right = false;
    float steer = 0.0025f;
    float yspeed = 0f;

   // public float fuel = 2;
     
     
     // Use this for initialization
     void FixedUpdate () {
         
         
         if(front){
             xspeep += power;
            // fuel -= power;
         }
         if(back){
             xspeep -= power;
            // fuel -= power;
         }

        if (right)
        {
            yspeed += steer;
            // fuel -= power;
        }
        if (left)
        {
            yspeed -= steer;
            // fuel -= power;
        }
    }
     
     // Update is called once per frame
     void Update () {
         
         if(Input.GetKeyDown("w")){
             front = true;
         }
         if(Input.GetKeyUp("w")){
             front = false;
         }
         if(Input.GetKeyDown("s")){
             back = true;
         }
         if(Input.GetKeyUp("s")){
             back = false;
         }

        if (Input.GetKeyDown("a"))
        {
            left = true;
        }
        if (Input.GetKeyUp("a"))
        {
            left = false;
        }

        if (Input.GetKeyDown("d"))
        {
            right = true;
        }
        if (Input.GetKeyUp("d"))
        {
            right = false;
        }

        //if (fuel < 0){
             
        //     xspeep = 0;
             
        // }
         
         xspeep *= friction;
         yspeed *=  friction;
        transform.Translate(Vector3.right * xspeep);
        transform.Translate(Vector3.back * yspeed);


    }
 }