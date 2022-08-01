using UnityEngine;

public class CloudMovement : MonoBehaviour
{

    private float speed;
    private float endPositionX;

    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.right);

        if (transform.position.x > endPositionX)
        {
            Destroy(gameObject);
        }
    }

    public void StartFloating(float speed, float endPositionX)
    {
        this.speed = speed;
        this.endPositionX = endPositionX;
    }
}
