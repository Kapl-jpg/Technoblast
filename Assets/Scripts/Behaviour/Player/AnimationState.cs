using UnityEngine;

public class AnimationState : CharacterAnimatorController
{
    private static readonly int IsGrounded = Animator.StringToHash("IsGrounded");
    private static readonly int Movement = Animator.StringToHash("Movement");
    private static readonly int WaveSide = Animator.StringToHash("WaveSide");
    private static readonly int WaveUp = Animator.StringToHash("WaveUp");
    private static readonly int WaveBelow = Animator.StringToHash("WaveBelow");
    private static readonly int SpeedY = Animator.StringToHash("SpeedY");

    public void SetHorizontalMovement(bool movement)
    {
        Animator.SetBool(Movement,movement);
    }

    public void SetGrounded(bool isGrounded)
    {
        Animator.SetBool(IsGrounded,isGrounded);
    }

    public void SetSpeedY(float speed)
    {
        Animator.SetFloat(SpeedY,speed);
    }

    public void SetLaunchWave(Vector3 direction)
    {
        if (direction == Vector3.up)
            SetWaveUp();
        if (direction == Vector3.down)
            SetWaveBelow();
        if(direction.x !=0)
            SetWaveSide();
    }

    #region Waves animation
    
    private void SetWaveSide()
    {
        Animator.SetTrigger(WaveSide);
        Animator.ResetTrigger(WaveBelow);
        Animator.ResetTrigger(WaveUp);
    }

    private void SetWaveUp()
    {
        Animator.SetTrigger(WaveUp);
        Animator.ResetTrigger(WaveBelow);
        Animator.ResetTrigger(WaveSide);
    }   

    private void SetWaveBelow()
    {
        Animator.SetTrigger(WaveBelow);
        Animator.ResetTrigger(WaveUp);
        Animator.ResetTrigger(WaveSide);
    }

    #endregion
}
