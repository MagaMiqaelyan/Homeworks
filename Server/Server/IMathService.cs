namespace Server
{
    public interface IMathService
    {
        double Add(double firstValue, double secondValue);
        double Sub(double firstValue, double secondValue);
        double Div(double firstValue, double secondValue);
        double Mult(double firstValue, double secondValue);
    }
}
