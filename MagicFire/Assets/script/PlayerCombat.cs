using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    private Animator animator;
    private PlayerControls controls;
    private bool isCasting = false;

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
        animator.SetTrigger("Decharge");
    }

    void Update()
    {
        if (isCasting)
        {
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

            if (stateInfo.IsName("Wizard Decharge_Clip") && stateInfo.normalizedTime >= 0.95f)
            {
                isCasting = false;
            }
        }
    }
}
