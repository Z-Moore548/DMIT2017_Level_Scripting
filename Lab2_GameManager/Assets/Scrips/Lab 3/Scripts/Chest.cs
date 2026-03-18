using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject player, containerPrefab;
    public InventoryContainer container;
    bool chestOpen = false;
    GameObject inventorytmp;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag != "Player") return;
        player = other.gameObject;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag != "Player") return;
        CloseChest();
        player = null;
    }

    void Update()
    {
        if(player != null && player.GetComponent<TopDownPlayerMovement>().interact == true)
        {
            if (!chestOpen)
            {
                chestOpen = true;
                openchest();
            }
            
        }
    }

    void openchest()
    {
        player.GetComponent<TopDownPlayerMovement>().interact = false;
        inventorytmp = Instantiate(containerPrefab);
        inventorytmp.GetComponent<ContainerUI>().InitUI(container);
    }

    void CloseChest()
    {
        Destroy(inventorytmp);
        chestOpen = false;
    }
}
