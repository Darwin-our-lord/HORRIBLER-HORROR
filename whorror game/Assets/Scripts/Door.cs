using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject world;
    public GameObject mirrorWorld;

    public bool isVertical;
    public bool isMirrorWorld;

    private float entrySide;

    void Awake()
    {
        mirrorWorld = GameObject.Find("MirrorHouse");
        world = GameObject.Find("House");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player") || collision.gameObject.CompareTag("box")) return;

        if (!isVertical)
        {
            Vector2 directionToPlayer = collision.gameObject.transform.position - transform.position;

            entrySide = Vector2.Dot(directionToPlayer, transform.right);
        }
        else
        {
            Vector2 directionToPlayer = collision.gameObject.transform.position - transform.position;

            entrySide = Vector2.Dot(directionToPlayer, transform.up);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player") || collision.gameObject.CompareTag("box")) return;

        float exitSide;
        if (!isVertical)
        {

            Vector2 directionToPlayer = collision.gameObject.transform.position - transform.position;
            exitSide = Vector2.Dot(directionToPlayer, transform.right);
        }
        else
        {
            Vector2 directionToPlayer = collision.gameObject.transform.position - transform.position;
            exitSide = Vector2.Dot(directionToPlayer, transform.up);
        }


        if (entrySide * exitSide < 0)
        {
            ToggleMirrorWorld(collision.gameObject);
        }
    }

    void ToggleMirrorWorld(GameObject obj)
    {

        if (isMirrorWorld)
        {
            obj.transform.position += new Vector3(1000,0,0);
        }
        else
        {
            obj.transform.position += new Vector3(-1000, 0, 0);
        }
        if (obj.CompareTag("player")) obj.GetComponent<PlayerController>().cam.transform.position = obj.transform.position;
    }
}
