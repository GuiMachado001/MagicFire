using UnityEngine;

public class Fireball : MonoBehaviour
{
    public Vector2 direction;
    public float speed = 8f;

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(gameObject);
    }
}
