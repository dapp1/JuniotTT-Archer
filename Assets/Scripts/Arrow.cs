using Unity.VisualScripting;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody2D _rb;

    public bool onTarget;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        if (!onTarget)
        {
            ActivateRb();
            Push(PigController.force);
        }
    }

    public void Push(Vector2 force)
    {
        _rb.AddForce(force, ForceMode2D.Impulse);
    }

    public void ActivateRb()
    {
        _rb.isKinematic = false;
    }

    public void DesactivateRb()
    {
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = 0f;
        _rb.bodyType = RigidbodyType2D.Static;
        onTarget = true;
    }
}
