using UnityEngine;

public class BasicTile1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject point;

    public Vector3 GetPointPosition()
    {
        return point.transform.position;
    }
}
