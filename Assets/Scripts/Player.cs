using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [Header("Assigned In Editor")]
    public GameObject foodPrefab;
    public PlayerData playerData;

    private float playSpaceSize = 9f; //The play space is just smaller than 10 units so the food spawns inside the walls
    private int foodLayer = 8; //The layer of the food for checking collision
    public Rigidbody myRigidBody;
    private float moveSpeed = 1;
    

    void Start()
    {
        myRigidBody.GetComponent<Rigidbody>();
        ResetPlayerData();
        SpawnFood();
    }

    void Update()
    {
            myRigidBody.velocity = transform.forward * moveSpeed;

        //If we hit the walls (which are all 10 units from the origin) we lose
        if(transform.position.x >= 10 ||
            transform.position.y >= 10 ||
            transform.position.z >= 10)
        {
            Debug.Log("Out of bounds");
            playerData.didLose = true;
        }
    }

    void ResetPlayerData()
    {
        playerData.score = 0;
        playerData.didLose = false;
    }

    void SpawnFood()
    {
        // Get a random position for our food to spawn, within the play bounds
        float randomX = Random.Range(-playSpaceSize, playSpaceSize);
        float randomY = Random.Range(-playSpaceSize, playSpaceSize);
        float randomZ = Random.Range(-playSpaceSize, playSpaceSize);
        Vector3 randomPosition = new Vector3(randomX, randomY, randomZ);

        // Create the food at the position with no rotation
        Instantiate(foodPrefab, randomPosition, Quaternion.identity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.layer == foodLayer)
        {
            //Destroy the food we hit
            Destroy(collision.gameObject);
            //Spawn new food
            SpawnFood();
            //Double our move speed
            moveSpeed *= 2;
            //Increment our score
            playerData.score++;
        }
    }
}
