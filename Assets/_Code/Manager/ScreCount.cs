using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreCount : MonoBehaviour
{
    public int score;
    public bool isCollided;
    public bool istriggered;
    [SerializeField]
    public float size;
    public float time;
    public float speed;
    private bool isStreak;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hoop"))
        {
            isCollided = true;

            //gameObject.transform.parent.GetComponent<FollowPath>().pathCreator = null;
            //gameObject.GetComponent<Rigidbody>().useGravity = true;
            //gameObject.GetComponent<Rigidbody>().AddForce(Vector3.down * 300f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Score"))
        {
            istriggered = true;
            if (isCollided)
            {
                score += 1;
            }
            else
            {
                score += 3;
                isCollided = false;
            }
            GameManager.instance.ScoreCount( score);
        }
        if (other.gameObject.CompareTag("LevelEnd"))
        {
            if (!istriggered)
            {
                GameManager.isgameOver = true;
                Time.timeScale = 0;
            }
        }
       
    }
   
}
