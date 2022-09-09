using UnityEngine;

public class AnimationState : CharacterAnimatorController
{
    private static readonly int IsGrounded = Animator.StringToHash("IsGrounded");
    private static readonly int WaveSide = Animator.StringToHash("WaveSide");
    private static readonly int WaveUp = Animator.StringToHash("WaveUp");
    private static readonly int WaveBelow = Animator.StringToHash("WaveBelow");
    private static readonly int SpeedY = Animator.StringToHash("SpeedY");
    private static readonly int SpeedX = Animator.StringToHash("SpeedX");
    private static readonly int Trick = Animator.StringToHash("Trick");

    public void SetGrounded(bool isGrounded)
    {
        Animator.SetBool(IsGrounded, isGrounded);
        ResetWaves(isGrounded);
    }

    public void SetSpeedX(float speed)
    {
        Animator.SetFloat(SpeedX, speed);
    }

    public void SetSpeedY(float speed)
    {
        Animator.SetFloat(SpeedY, speed);
    }

    public void SetLaunchWave(Vector3 direction)
    {
        switch (direction)
        {
            case var v when v.Equals(Vector3.down):
                SetWaveBelow();
                break;
            case var v when v.Equals(Vector3.up):
                SetWaveUp();
                break;
            case var v when v.Equals(Vector3.left):
                SetWaveSide();
                break;
            case var v when v.Equals(Vector3.right):
                SetWaveSide();
                break;
        }
    }
    
    public void SetTrick(bool trick)
    {
        Animator.SetBool(Trick, trick);
    }

    #region Waves animation

    private void SetWaveSide()
    {
        Animator.SetBool(WaveSide, true);
    }

    private void SetWaveUp()
    {
        Animator.SetBool(WaveUp, true);
    }

    private void SetWaveBelow()
    {
        Animator.SetBool(WaveBelow, true);
    }

    private void ResetWaves(bool isGrounded)
    {
        if (!isGrounded)
            return;
        
        Animator.SetBool(WaveBelow, false);
        Animator.SetBool(WaveSide, false);
        Animator.SetBool(WaveUp, false);
    }

    #endregion
}
