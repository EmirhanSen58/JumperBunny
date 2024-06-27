using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 20f;  // Hareket hýzý
    public float jumpForce = 20f;  // Zýplama kuvveti

    private Rigidbody2D rb;
    private bool isDragging = false;
    private Vector2 touchStartPos;

    void Start()
    {
        // Rigidbody2D bileþenini al
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Mobilde sürükleme hareketlerini kontrol et
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                isDragging = true;
                touchStartPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                if (isDragging)
                {
                    Vector2 touchDelta = touch.position - touchStartPos;
                    Vector3 newPosition = new Vector3(touchDelta.x * moveSpeed * Time.deltaTime, rb.position.y, 0);
                    rb.MovePosition(newPosition);
                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isDragging = false;
            }
        }

        // Fare ile kontrol (PC testi için)
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            touchStartPos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            if (isDragging)
            {
                Vector2 mouseDelta = (Vector2)Input.mousePosition - touchStartPos;
                Vector3 newPosition = new Vector3(mouseDelta.x * moveSpeed * Time.deltaTime, rb.position.y, 0);
                rb.MovePosition(newPosition);
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Eðer karakter bir bloða deðerse
        if (collision.gameObject.CompareTag("Block"))
        {
            // Karakterin alttan çarpmasý durumunda zýplama kuvveti uygula
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if  (contact.normal.y > 0.1f)
                {
                    Debug.Log("yukarda");
                    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                    BlockController blockControllerý = collision.gameObject.GetComponent<BlockController>();
                    if (blockControllerý != null)
                    {

                        blockControllerý.ReactivateCollider();
                    }
                }
                else if (contact.normal.y < -0.5f)
                {
                    // Karakterin üstten çarpmasý durumunda bloðun collider'ýný geçici olarak pasif yap
                    BlockController blockController = collision.gameObject.GetComponent<BlockController>();
                    if (blockController != null)
                    {
                        blockController.DisableColliderTemporarily();
                    }
                }
               
            }
        }
    }
}
