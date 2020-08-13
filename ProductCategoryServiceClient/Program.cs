using System;

namespace ProductCategoryServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please wait for service to run and then press any key");
            Console.ReadLine();
            ServiceTestClient client = new ServiceTestClient();
            client.TestService();

        }
    }
}
