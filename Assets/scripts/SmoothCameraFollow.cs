using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.youtube.com/watch?v=8rnRvotQmdg

public class SmoothCameraFollow : MonoBehaviour
{

    [SerializeField] private Vector3 offset;
    [SerializeField] private float damping;

    public Transform target;
    private Vector3 vel = Vector3.zero;

    private void FixedUpdate() {

        if (target != null ) {
            Vector3 targetPosition = target.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref vel, damping);
        }

    }

    public void setTarget(Transform new_target){
        // Debug.Log("setTarget");
        target = new_target;
    }

    public void testLog(){
        string log_text = "hello from scf";
        Debug.Log(log_text);
    }


}
