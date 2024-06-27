using UnityEngine;

public class BlockController : MonoBehaviour
{
    public Collider2D coll;
    public bool isActive = true; // Collider'�n aktif/pasif durumunu takip etmek i�in bir flag
    public float disableDuration = 0.5f; // Collider'�n ne kadar s�reyle devre d��� b�rak�laca��

    void Start()
    {
        coll = GetComponent<Collider2D>();
    }

    // Karakterin alt�nda ise collider'� aktif yap
    public void ActivateCollider()
    {
        isActive = true;
        coll.enabled = true;
    }

    // Karakterin �st�nde ise collider'� belirli s�reli�ine pasif yap
    public void DisableColliderTemporarily()
    {
        isActive = false;
        coll.enabled = false;
        Invoke("ReactivateCollider", disableDuration); // Belirli bir s�re sonra collider'� tekrar aktif yap
    }

    // Collider'� tekrar aktif hale getirmek i�in kullan�labilir
    public void ReactivateCollider()
    {
        isActive = true;
        coll.enabled = true;
    }

    // Collider'�n durumunu d�nd�rmek i�in bir metot
    public bool IsColliderActive()
    {
        return isActive;
    }
}
