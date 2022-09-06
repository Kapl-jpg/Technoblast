using UnityEngine;

public class JumpableObjectData 
{
    public int ObjectForce { get; private set; }
    public Material ObjectMaterial { get; private set; }
    public AudioClip ObjectHitAudio { get; private set; }

    public Color WaveColor { get; private set; }

    public JumpableObjectData(int objectForce, Material objectMaterial, AudioClip objectHitSound,Color waveColor)
    {
        ObjectForce = objectForce;
        ObjectMaterial = objectMaterial;
        ObjectHitAudio = objectHitSound;
        WaveColor = waveColor;
    }
}
