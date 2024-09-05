using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{

    public GameObject PointA;
    public GameObject PointB;
    private Rigidbody2D rb;
    private Transform currentPoint;
    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = PointB.transform;
    }


    private void Update()
    {

        if (currentPoint == PointB.transform)
        {
            // Debug.Log("forward");
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            // Debug.Log("Backward");

            rb.velocity = new Vector2(-speed, 0);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointB.transform)
        {

            
            currentPoint = PointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointA.transform)
        {
            
            currentPoint = PointB.transform;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(PointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(PointB.transform.position, 0.5f);

        Gizmos.DrawLine(PointA.transform.position, PointB.transform.position);

    }
}
