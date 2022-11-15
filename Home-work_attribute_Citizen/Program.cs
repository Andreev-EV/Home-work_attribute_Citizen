namespace Home_work_attribute_Citizen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Citezen citezen = new Citezen("Евгений", "2.12.1983", "8(906) 000-00-00", "70 01 111111", "Тула, ул. Октябрьская, д. 122");
            citezen.CreateCitezen();
        }
    }
}