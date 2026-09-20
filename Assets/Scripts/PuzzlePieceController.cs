using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzlePieceController : MonoBehaviour
{
    private Vector3 mousePosition;
	public float moveSpeed = 0.2f;
    bool canDrag = true;
    bool isMoving = false;
    Collider2D collidedObject;
    
    void Update()
    {
        mousePosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(isMoving) GetComponent<Transform>().position = Vector2.Lerp(GetComponent<Transform>().position, mousePosition, moveSpeed);
    }

    private void OnMouseDown()
    {
        if (canDrag == true) isMoving = true;
        UnityEngine.Debug.Log("Piece ID: " + GetComponent<UniqueIdentifier>().GetIdentifier());
    }
    
    private void OnMouseUp()
    {
        isMoving = false;
        if (collidedObject != null)
        {
            if (collidedObject.gameObject.tag == "Tile")
            {
                if (collidedObject.gameObject.GetComponent<UniqueIdentifier>() != null)
                {
                    UnityEngine.Debug.Log("Tile ID: " + collidedObject.gameObject.GetComponent<UniqueIdentifier>().GetIdentifier());
                    if (collidedObject.gameObject.GetComponent<UniqueIdentifier>().GetIdentifier() == GetComponent<UniqueIdentifier>().GetIdentifier())
                    {
                        lockPiece();
                        GameController.CollectPiece();
                    }
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        collidedObject = collider;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        collidedObject = null;
    }

    void lockPiece()
    {
        canDrag = false;
        isMoving = false;
        GetComponent<Transform>().position = collidedObject.gameObject.GetComponent<Transform>().position;
        GetComponent<Transform>().rotation = collidedObject.gameObject.GetComponent<Transform>().rotation;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
