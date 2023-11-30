using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopMovementController : MonoBehaviour
{
    public static HoopMovementController instance;
    public float minXLimit, maxXLimit;
    public float movementSpeed;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (!GameManager.isgameOver)
        {
            if (Input.touchCount > 0)
            {
                if (gameObject)
                {
                    Touch touch = Input.GetTouch(0);
                    if (touch.phase == TouchPhase.Moved)
                    {
                        Vector3 deltaPos = new Vector3(touch.deltaPosition.x, 0, 0);
                        Vector3 desiredPosition = gameObject.transform.position - deltaPos * movementSpeed * Time.deltaTime;
                        float clampedX = Mathf.Clamp(desiredPosition.x, minXLimit, maxXLimit);
                        desiredPosition.x = clampedX;
                        gameObject.transform.position = desiredPosition;
                    }
                }
            }
        }
    }

   

}
