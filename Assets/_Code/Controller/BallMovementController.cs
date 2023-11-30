using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
public class BallMovementController : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPosition;
    [SerializeField]
    private GameObject ballPrefab;
    public GameObject ball;
    private Rigidbody rb;
    [SerializeField]
    private float spawnDelay;
    private MeshRenderer ballMesh;
    public Material blackBallMaterial;
    public Material defaultMaterial;
    public PathCreator pathCreator;
    [SerializeField]
    private int scoreCheck;

    private void Start()
    {
        InvokeRepeating("SpawnPlayerBall", 1f, spawnDelay);
    }
   
    private void SpawnPlayerBall()
    {
        if (GameManager.instance.playerScore >= scoreCheck)
        {
            StartCoroutine(SpawnTripleBall());
            scoreCheck += 30;
        }
        else
        {
            Vector3 spawnPoint = new Vector3(spawnPosition.position.x, spawnPosition.position.y, spawnPosition.position.z);
            ball = Instantiate(ballPrefab, spawnPoint, Quaternion.identity);
            rb = ball.transform.GetChild(0).GetComponent<Rigidbody>();
            SetBallChildPosition();
            setPathFollower();
            ballMesh = ball.transform.GetChild(0).GetComponent<MeshRenderer>();
            changeBallMaterial();
        }
        if (GameManager.isgameOver)
        {
            CancelInvoke("SpawnPlayerBall");
        }
        spawnDelay = GameManager.instance.spawnDelay;
    }
    private IEnumerator SpawnTripleBall()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSecondsRealtime(0.1f);
            Vector3 spawnPoint = new Vector3(spawnPosition.position.x, spawnPosition.position.y, spawnPosition.position.z);
            ball = Instantiate(ballPrefab, spawnPoint, Quaternion.identity);
            rb = ball.transform.GetChild(0).GetComponent<Rigidbody>();
            setPathFollower();
            ballMesh = ball.transform.GetChild(0).GetComponent<MeshRenderer>();
            changeBallMaterial();
        }
    }
    private void SetBallChildPosition()
    {
        float Xpos = Random.Range(-1, 2);
        Vector3 newPosition = new Vector3(ball.transform.position.x + Xpos, ball.transform.position.y, ball.transform.position.z);
        ball.transform.GetChild(0).transform.position = newPosition;
        rb.AddTorque(new Vector3(-1, 0, 0)*100f , ForceMode.Force);
    }
    private void setPathFollower()
    {
        ball.GetComponent<FollowPath>().pathCreator = pathCreator;
    }
   
    private void changeBallMaterial()
    {
        if (GameManager.instance.streakCount >= 2)
        {
            ballMesh.material = blackBallMaterial;
        }
        else
        {
            ballMesh.material = defaultMaterial;
        }
    }

}

