using UnityEngine;

 

public class CameraController : MonoBehaviour

{

    public float moveSpeed = 5f;

 

    void Update()

    {

        // Get input for camera movement

        float horizontal = Input.GetAxis("Horizontal");

        float vertical = Input.GetAxis("Vertical");

 

        // Calculate movement direction

        Vector3 movement = new Vector3(horizontal, 0, vertical).normalized;

 

        // Move the player in the camera's forward direction

        transform.Translate(movement * moveSpeed * Time.deltaTime);

    }

}

 