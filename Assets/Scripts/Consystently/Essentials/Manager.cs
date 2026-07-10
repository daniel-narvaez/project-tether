namespace Consystently.Essentials
{
  public class Manager<T> : Singleton<T> where T : Singleton<T>
  {
    protected override void Awake()
    {
      base.Awake();
    }
  }
}
