namespace WebAPI.APP.Services
{
    public class InnerPlusTenService : IInnerService
    {
        private readonly int _maxNumber;

        public InnerPlusTenService(int maxNumber) 
        {
            _maxNumber = maxNumber;
        }

        public int DoSomething() 
        {
            return _maxNumber + 10;
        }

        public void UpdateState() { }
    }
}
