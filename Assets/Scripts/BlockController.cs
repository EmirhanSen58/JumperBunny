using UnityEngine;

public class BlockController : MonoBehaviour
{
    public Collider2D coll;
    public bool isActive = true; // Collider'ýn aktif/pasif durumunu takip etmek için bir flag
    public float disableDuration = 0.5f; // Collider'ýn ne kadar süreyle devre dýþý býrakýlacaðý

    void Start()
    {
        coll = GetComponent<Collider2D>();
    }

    // Karakterin altýnda ise collider'ý aktif yap
    public void ActivateCollider()
    {
        isActive = true;
        coll.enabled = true;
    }

    // Karakterin üstünde ise collider'ý belirli süreliðine pasif yap
    public void DisableColliderTemporarily()
    {
        isActive = false;
        coll.enabled = false;
        Invoke("ReactivateCollider", disableDuration); // Belirli bir süre sonra collider'ý tekrar aktif yap
    }

    // Collider'ý tekrar aktif hale getirmek için kullanýlabilir
    public void ReactivateCollider()
    {
        isActive = true;
        coll.enabled = true;
    }

    // Collider'ýn durumunu döndürmek için bir metot
    public bool IsColliderActive()
    {
        return isActive;
    }
}
