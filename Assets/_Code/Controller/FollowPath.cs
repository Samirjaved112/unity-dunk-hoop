using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
public class FollowPath : MonoBehaviour
{
    public PathCreator pathCreator;
    public float forwardMovingspeed;
    public float distanceTravelled;
    public GameObject playerPrefab;
    private Rigidbody rb;
    private void Start()
    {
        rb = gameObject.transform.GetChild(0).GetComponent<Rigidbody>();
        forwardMovingspeed = GameManager.instance.ballSpeed;
    }
    private void Update()
    {
        if (pathCreator != null)
        {
            distanceTravelled += forwardMovingspeed * Time.deltaTime;
            ForwardMovement();
        }
        
    }
    private void ForwardMovement()
    {
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, EndOfPathInstruction.Stop);
        if (distanceTravelled >= pathCreator.path.length)
        {
            pathCreator = null;
            rb.useGravity = true;
            rb.AddForce(new Vector3(0, -1, 0.5f) * 300f);
        }
    }

}
