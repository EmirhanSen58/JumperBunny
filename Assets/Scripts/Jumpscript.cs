using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;  // Hareket h�z�
    public float jumpForce = 10f;  // Z�plama kuvveti

    private Rigidbody2D rb;
    private bool isDragging = false;
    private Vector2 touchStartPos;

    void Start()
    {
        // Rigidbody2D bile�enini al
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Mobilde s�r�kleme hareketlerini kontrol et
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

        // Fare ile kontrol (PC testi i�in)
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
        // E�er karakter bir blo�a de�erse
        if (collision.gameObject.CompareTag("Block"))
        {
            // Y eksenine z�plama kuvveti uygula
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
