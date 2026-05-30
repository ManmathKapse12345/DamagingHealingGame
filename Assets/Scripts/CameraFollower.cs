using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public GameObject objectFollowed;
    private float rotationSpeed = 50f;
    private Vector3 offset = new Vector3(0,2,-4);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = objectFollowed.transform.position + offset;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Quaternion rotation = Quaternion.AngleAxis(horizontalInput*rotationSpeed*Time.deltaTime,Vector3.up);
        offset = rotation*offset;
        transform.position = objectFollowed.transform.position + offset;
        // transform.RotateAround(objectFollowed.transform.position,Vector3.up,Time.deltaTime*rotationSpeed*horizontalInput);
        transform.LookAt(objectFollowed.transform.position);
    }
}
