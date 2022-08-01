using UnityEngine;

public class CloudGenerator : MonoBehaviour
{
    public GameObject[] clouds;
    public float spawnInterval;
    public float speed;
    public GameObject endPoint;
    public GameObject startPoint;
    Vector3 StartPosition;

    int counter = 0;
    float[] startY = new float[5];

    private void Start()
    {
        startY[0] = -5;
        startY[1] = 11;
        startY[2] = 0;
        startY[3] = -20;
        startY[4] = 7;

        StartPosition = startPoint.transform.position;
        Prewarm();
        Invoke(nameof(AttemptSpawn), spawnInterval);
    }

    void SpawnCloud(Vector3 startPosition)
    {
        int randomIndex = Random.Range(0, clouds.Length);
        GameObject cloud = Instantiate(clouds[randomIndex], transform, false);

        cloud.GetComponent<CloudMovement>().StartFloating(speed, endPoint.transform.position.x);
        cloud.transform.position = new Vector3(startPosition.x, startPosition.y + startY[counter], startPosition.z);

        counter++;
        if (counter > 4)
        {
            counter = 0;
        }

    }

    void AttemptSpawn()
    {
        SpawnCloud(StartPosition);
        Invoke(nameof(AttemptSpawn), spawnInterval);
    }

    void Prewarm()
    {
        for (int i = 1; i < 10; i++)
        {
            Vector3 SpawnPosition = StartPosition + Vector3.right * (i * 30);
            SpawnCloud(SpawnPosition);
        }
    }
}
