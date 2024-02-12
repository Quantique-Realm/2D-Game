using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_follow : MonoBehaviour
{
    private float FollowSpeed = 2f;
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector3 newpos = new Vector3(target.position.x, target.position.y, -10f);
            transform.position = Vector3.Slerp(transform.position, newpos, FollowSpeed * Time.deltaTime);
        }
        else
        {
            
            Debug.LogWarning("Target is null. Stopping follow or setting a default position.");
            
        }
    }
}

