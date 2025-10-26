using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private Animator animator;
    private bool isCasting = false;
    private const KeyCode ATTACK_KEY = KeyCode.JoystickButton2; 

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        if (Input.GetKeyDown(ATTACK_KEY) && !isCasting)
        {
            animator.SetTrigger("Cast");
            isCasting = true;
        }

        if (Input.GetKeyUp(ATTACK_KEY) && isCasting)
        {
            animator.SetTrigger("ReleaseSpell");
        }


        if (isCasting)
        {
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);


            bool isDecayState = stateInfo.IsName("Decay"); 
            

            if (isDecayState && stateInfo.normalizedTime >= 0.9f)
            {
                isCasting = false;
            }
        }
    }
    

}