namespace WebAPI.APP.Constrait
{
    public class TemperatureRouteConstraint : IRouteConstraint
    {
        private const int MIN_VALUE = -20;
        private const int MAX_VALUE = 55;

        public bool Match(HttpContext? httpContext, IRouter? route, 
            string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if(!values.TryGetValue(routeKey, out var value)) 
            {
                return false;
            }

            var convertedValue = Convert.ToInt32(value);
            return convertedValue >= MIN_VALUE && convertedValue <= MAX_VALUE;
        }
    }
}
