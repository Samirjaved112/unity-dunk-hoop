using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBall : MonoBehaviour
{
    private void Start()
    {
        Invoke("DestroyPlayerBall", 4f);
    }
    private void DestroyPlayerBall()
    {
        Destroy(gameObject);
    }
}
