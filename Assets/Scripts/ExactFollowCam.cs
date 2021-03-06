using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExactFollowCam : MonoBehaviour
{

    public Transform toFollow;
    private Vector3 offset;

    
    void Start()
    {
        //Whatever the relationship is between cam and followed object
        //At the start of the game is what it's going to keep
        offset = transform.position - toFollow.position;
    }


    // Update is called once per frame
    void Update()
    {
        if (toFollow != null)
        {
            Vector3 newPosition = toFollow.position + offset;
            newPosition.z = transform.position.z;
            transform.position = newPosition;
        }
    }
}
