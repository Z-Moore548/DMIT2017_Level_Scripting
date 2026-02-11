using UnityEngine;

public class InnSleep : MonoBehaviour
{
    GameObject player;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag != "Player") return;
        player = other.gameObject;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag != "Player") return;
        player = null;
    }

    void Update()
    {
        if(player != null)
        {
            if (player.GetComponent<TopDownPlayerMovement>().interact)
            {
                GameStateManager.Instance.ResetEnemies();
                player.GetComponent<TopDownPlayerMovement>().interact = false;
            }
        }
        
    }
}
