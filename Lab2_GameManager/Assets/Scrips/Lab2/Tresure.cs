using UnityEngine;

public class Tresure : MonoBehaviour
{
    public bool gotIt;
    public void ShowTresure(bool collected)
    {
        gotIt = collected;
        if (collected)
        { 
            gameObject.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<TopDownPlayerMovement>().tresureCollected++;
            gotIt = true;
            gameObject.SetActive(false);
        }
    }
}
