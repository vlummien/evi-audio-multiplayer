using UnityEngine;
using UnityEngine.Serialization;
using Unity.Netcode;

public class SphereMovement : NetworkBehaviour
{
    public float speed = 5f; // Speed of the sphere
    public float switchTime = 3f; // Time between position changes
    private bool moveInX; // true if sphere is moving in one direction and false in the other direction

    private float timer;
    
    public AudioClip soundClip;

    void Start()
    {
        RandomizeStartPositionClientRpc();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= switchTime)
        {
            RandomizeStartPositionClientRpc();
            timer = 0f;
        }

        MoveSphereClientRpc();
    }

    [ClientRpc]
    void RandomizeStartPositionClientRpc()
    {
        // Randomly choose the start position and movement direction
        transform.position = new Vector3(Random.Range(-5f, 5f), 0f, 0f);
        moveInX = Random.value > 0.5f;
    }

    [ClientRpc]
    void MoveSphereClientRpc()
    {
        // Move the sphere in the selected dimension
        float movement = speed * Time.deltaTime;
        int direction = moveInX ? 1 : -1;
        transform.Translate(new Vector3(movement * direction, 0f, 0f));
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        moveInX = !moveInX;
        timer = 0f;
        
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Play sound clip at position of collision
            AudioSource.PlayClipAtPoint(soundClip, collision.transform.position);

            RandomizeStartPositionClientRpc();
        }
    }
}