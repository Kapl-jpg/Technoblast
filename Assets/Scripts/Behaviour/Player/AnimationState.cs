using TMPro;
using UnityEngine;

public class AnimationState : CharacterAnimatorController
{
    [SerializeField] private float maxSpeedAxisX = 18;
    
    private static readonly int IsGrounded = Animator.StringToHash("IsGrounded");
    private static readonly int WaveSide = Animator.StringToHash("WaveSide");
    private static readonly int WaveUp = Animator.StringToHash("WaveUp");
    private static readonly int WaveDown = Animator.StringToHash("WaveDown");
    private static readonly int SpeedY = Animator.StringToHash("SpeedY");
    private static readonly int SpeedX = Animator.StringToHash("SpeedX");
    private static readonly int Trick = Animator.StringToHash("Trick");
    private static readonly int DirectionAxisX = Animator.StringToHash("DirectionAxisX");
    private static readonly int Death = Animator.StringToHash("Death");
    private static readonly int WinGame = Animator.StringToHash("WinGame");


    public void TriggerDeath()
    {
        Animator.SetTrigger(Death);
    }

    public void TriggerWinGame()
    {
        Animator.SetTrigger(WinGame);
    }
    
    public bool GetWaveSide()
    {
        return Animator.GetBool(WaveSide);
    }

    public void SetDirection(float direction)
    {
        if (direction > 0)
            Animator.SetInteger(DirectionAxisX, 1);
        if (direction < 0)
            Animator.SetInteger(DirectionAxisX, -1);
    }

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

    public void SetLaunchWave(Vector3 direction, bool isGrounded, float speedAxisX)
    {
        switch (direction)
        {
            case var v when v.Equals(Vector3.down):
                SetWaveDown(isGrounded, speedAxisX);
                break;
            case var v when v.Equals(Vector3.up):
                SetWaveUp(isGrounded, speedAxisX);
                break;
            case var v when v.Equals(Vector3.left):
                SetWaveSide();
                SetDirection(-1);
                break;
            case var v when v.Equals(Vector3.right):
                SetWaveSide();
                SetDirection(1);
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
        Animator.SetBool(WaveDown, false);
        Animator.SetBool(WaveUp,false);
    }

    private void SetWaveUp(bool isGrounded, float speedAxisX)
    {
        if(isGrounded)
            return;
        
        if(speedAxisX > maxSpeedAxisX)
            return;

        Animator.SetBool(WaveUp, true);
        Animator.SetBool(WaveDown, false);
        Animator.SetBool(WaveSide,false);
    }

    private void SetWaveDown(bool isGrounded, float speedAxisX)
    {
        if(isGrounded)
            return;
        
        if(speedAxisX > maxSpeedAxisX)
            return;

        Animator.SetBool(WaveDown, true);
        Animator.SetBool(WaveUp, false);
        Animator.SetBool(WaveSide,false);
    }

    private void ResetWaves(bool isGrounded)
    {
        if (!isGrounded)
            return;
        
        Animator.SetBool(WaveDown, false);
        Animator.SetBool(WaveSide, false);
        Animator.SetBool(WaveUp, false);
    }

    #endregion
}
