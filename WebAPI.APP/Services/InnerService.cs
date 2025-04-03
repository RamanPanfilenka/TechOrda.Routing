namespace WebAPI.APP.Services
{
    public class InnerService : IInnerService
    {
        private int _maxNumber;

        public InnerService(int maxNumber) 
        {
            _maxNumber = maxNumber;
        }

        public int DoSomething() 
        {
            return _maxNumber;
        }

        public void UpdateState() 
        {
            _maxNumber++;
        }
    }
}
