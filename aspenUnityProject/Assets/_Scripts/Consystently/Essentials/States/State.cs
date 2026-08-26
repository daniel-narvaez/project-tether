namespace Consystently.Essentials
{
    public interface State
    {
        public void Enter();
        public void Update();
        public void Exit();
    }
}