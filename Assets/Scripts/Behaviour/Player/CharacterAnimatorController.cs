using UnityEngine;

public abstract class CharacterAnimatorController : MonoBehaviour
{
    [SerializeField] private GameObject meshCharacter;
    
    protected Animator Animator;

    private void Start()
    {
        Animator = meshCharacter.GetComponent<Animator>();
    }
}
