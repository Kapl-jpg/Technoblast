public class BulletColor : JumpableObject
{
  public void Init(ForceColor color)
     {
         _objectData = _colorForceConfig.GetData(color);
         SetColor();
     }
}
