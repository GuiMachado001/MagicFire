using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    private Animator animator;
    private PlayerControls controls;

    private bool isCasting = false;

    public Transform firePoint;
    public GameObject fireBallPrefab;

    void Awake()
    {
        animator = GetComponent<Animator>();
        controls = new PlayerControls();
    }

    private void OnEnable()
    {
        controls.Player.Enable();
        controls.Player.Spell.performed += ctx => StartCasting();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
    }

    private void StartCasting()
    {
        if (isCasting) return;

        isCasting = true;
        animator.SetBool("isCasting", true);
        animator.SetFloat("speed", 0);
    }

    public void ShootFireball()
    {
        GameObject fireball = Instantiate(fireBallPrefab, firePoint.position, Quaternion.identity);

        Fireball fb = fireball.GetComponent<Fireball>();
        Vector2 direction = transform.localScale.x > 0 ? Vector2.right : Vector2.left;
        fb.direction = direction;
    }


    public void EndCast()
    {
        isCasting = false;
        animator.SetBool("isCasting", false);
    }

}
