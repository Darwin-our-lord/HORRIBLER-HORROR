using UnityEngine;

public class Door : MonoBehaviour
{

    public bool isVertical;
    public bool isMirrorWorld;
    public bool mirrorchanger;

    private float entrySide;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player") || !collision.gameObject.CompareTag("Box"));
        else return;
        
        //play door open anim


        if (mirrorchanger)
        {

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
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player") || !collision.gameObject.CompareTag("Box"));
        else return;

        //play door close anim


        if (mirrorchanger)
        {
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
        if (obj.CompareTag("Player")) obj.GetComponent<PlayerController>().cam.transform.position = obj.transform.position;
    }
}
