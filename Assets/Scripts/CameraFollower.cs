using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public GameObject objectFollowed;
    private Vector3 offset = new Vector3(0,2,-3);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = objectFollowed.transform.position + offset;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = objectFollowed.transform.position + offset;
    }
}
