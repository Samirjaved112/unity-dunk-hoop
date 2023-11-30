using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowStrakEffect : MonoBehaviour
{
    public float growthRate = 1.0f;
    [SerializeField]
    private float scaleSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x <= 0.4f)
        {
           transform.localScale += new Vector3(growthRate, growthRate, growthRate) * scaleSpeed * Time.fixedDeltaTime;
            if (transform.localScale.x >= 0.4f)
            {
                Destroy(gameObject);
            }
        }
    }
}
