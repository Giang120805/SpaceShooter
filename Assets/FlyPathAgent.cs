using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyPathAgent : MonoBehaviour
{
    public FlyPath flyPath;
    public float flySpeed = 3f;

    private int nextIndex = 1;

    void Start()
    {
        if (flyPath == null || flyPath.waypoints.Length == 0)
            return;
        transform.position = flyPath[0];
        nextIndex = 1;
    }

    void Update()
    {
        if (flyPath == null) return;

        if (nextIndex >= flyPath.waypoints.Length)
        {
            Destroy(gameObject);
            return;
        }

        if (Vector2.Distance(transform.position, flyPath[nextIndex]) > 0.1f)
        {
            FlyToNextWaypoint();
            LookAt(flyPath[nextIndex]);
        }
        else
        {
            nextIndex++;
        }
    }

    private void FlyToNextWaypoint()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            flyPath[nextIndex],
            flySpeed * Time.deltaTime
        );
    }

    private void LookAt(Vector2 destination)
    {
        Vector2 position = transform.position;
        Vector2 lookDirection = destination - position;

        if (lookDirection.magnitude < 0.01f) return;

        float angle = Vector2.SignedAngle(Vector2.down, lookDirection);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}