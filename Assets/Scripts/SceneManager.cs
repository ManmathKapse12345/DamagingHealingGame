using UnityEngine;

public class SceneManager : MonoBehaviour
{
    private const int numberOfObjects = 6;
    public GameObject[] vfxObjects = new GameObject[numberOfObjects];
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int prev_j = -1;
        int j;
        Vector3 spawnPosition;
        for (int i = 0; i < 100; i++)
        {
            float spawnX = Random.Range(-9f, 9f);
            float spawnZ = Random.Range(1f, 994f);
            do
            {
                j = Random.Range(0, numberOfObjects);
            }
            while (j == prev_j);
            if (j == 0)
            {
                spawnPosition = new Vector3(spawnX, 1f, spawnZ);
            }
            else
            {
                spawnPosition = new Vector3(spawnX, 0.15f, spawnZ);
            }
            Instantiate(vfxObjects[j], spawnPosition, vfxObjects[j].transform.rotation);
            prev_j = j;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
