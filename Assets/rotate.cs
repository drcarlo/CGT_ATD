using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    private Quaternion startingRotation;
    public float speed = 10;

    void Start(){
        //save the starting rotation
        startingRotation = this.transform.rotation;
    }

    void Update () {
        //return back to the starting rotation
        if( Input.GetKeyUp( KeyCode.E ) ){
            StopAllCoroutines();
            StartCoroutine(Rotate(0));
        }

        //go to 90 degrees with right arrow
        if( Input.GetKeyDown( KeyCode.E ) ){
            StopAllCoroutines();
            StartCoroutine(Rotate(45));
        }
    }

    IEnumerator Rotate(float rotationAmount){
        Quaternion finalRotation = Quaternion.Euler( 0, 0, rotationAmount ) * startingRotation;

        while(this.transform.rotation != finalRotation){
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, finalRotation, Time.deltaTime*speed);
            yield return 0;
        }
    }
}


