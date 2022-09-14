using UnityEngine;

public class BulletColor : JumpableObject
{
  protected override void Init()
     {
         
     }
 
     public void InitColor(Material colorMaterial)
     {
         if (_emissionElementMeshRenderer == null) return;
         
         foreach (var meshRenderer in _emissionElementMeshRenderer)
         {
             meshRenderer.material = colorMaterial;
         }
     }

     public void SetJumpableOnjectData(JumpableObjectData jumpableObjectData)
     {
         _objectData = jumpableObjectData;
     }
}
