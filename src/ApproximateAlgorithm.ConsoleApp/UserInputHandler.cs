namespace ApproximateAlgorithm.ConsoleApp
{
    public static class UserInputHandler
    {
        public static int ReadInt(string inputMessage)
        {
            int intInput;
            Console.Write(inputMessage);
            try
            {
                intInput = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Tipo de entrada inválida, tente novamente. {0}", ex.Message);
                intInput = ReadInt(inputMessage);
            }

            return intInput;
        }

        public static short ReadShort(string inputMessage)
        {
            short shortInput;
            Console.Write(inputMessage);
            try
            {
                shortInput = Convert.ToInt16(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Tipo de entrada inválida, tente novamente. {0}", ex.Message);
                shortInput = ReadShort(inputMessage);
            }

            return shortInput;
        }
    }
}
