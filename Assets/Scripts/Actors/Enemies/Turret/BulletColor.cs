using UnityEngine;

public class BulletColor : JumpableObject
{
  protected override void Init()
     {
         _objectData = _colorForceConfig.GetData(_color);
     }
 
     public void InitColor(Material colorMaterial)
     {
         if (_emissionElementMeshRenderer == null) return;
         
         foreach (var meshRenderer in _emissionElementMeshRenderer)
         {
             meshRenderer.material = colorMaterial;
         }
     }
}
