using UnityEngine;

public class TileName : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private string tileNamePrefix;

    [SerializeField] private Vector3 tilePosition;

    private void OnValidate()
    {
        this.name = $"{tileNamePrefix}_({tilePosition.x}, {tilePosition.y}, {tilePosition.z})";
    }
}
