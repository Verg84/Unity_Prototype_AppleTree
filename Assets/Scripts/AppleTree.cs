using UnityEngine;

public class AppleTree : MonoBehaviour
{
    // apple prefab
    public GameObject applePrefab;

    
    public float speed = 1f;
    public float leftAndRightAngle = 10f;
    public float chanceToChangeDirections = 0.1f;
    public float secondsBetweenAppleDrops = 1f;

    void Start()
    {
        // Dropping apples every second
        InvokeRepeating("DropApple", 2f, secondsBetweenAppleDrops);
    }

    private void Update()
    {
        // Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        // Change Direction
        if (pos.x<-leftAndRightAngle)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightAngle)
        {
            speed = -Mathf.Abs(speed);
        }
       
    }

    private void FixedUpdate()
    {
        if(Random.value<chanceToChangeDirections)
        {
            speed *= -1;
        }
    }

    void DropApple()
    {
        GameObject apple = Instantiate(applePrefab) as GameObject;
        apple.transform.position = transform.position;
    }
}
