using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using Vector2 = UnityEngine.Vector2;

public class FollowCamera : MonoBehaviour
{
    public GameObject player;
    float smoothTime = 0.3f;
    Vector3 Velocity = Vector3.zero;
    public int yOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayerObj();
    }

    void FollowPlayerObj() 
    {
        Vector3 targetPos = player.transform.TransformPoint(new Vector3(0, yOffset, -10));
        targetPos = new Vector3(0, targetPos.y, targetPos.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref Velocity, smoothTime);
    }
}
