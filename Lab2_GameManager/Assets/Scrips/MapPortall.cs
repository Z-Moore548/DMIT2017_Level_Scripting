using UnityEngine;

public class MapPortall : MonoBehaviour
{
    public int targetMap;
    public int targetEntryPoint;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "Player") return;
        MapNavagation.Instance.GoToMap(targetMap, targetEntryPoint);
    }
}
