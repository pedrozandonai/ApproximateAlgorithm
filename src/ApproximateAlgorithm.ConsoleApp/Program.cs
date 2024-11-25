using System.Diagnostics;

namespace ApproximateAlgorithm.ConsoleApp
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            InitialDisplay();

            var items = new List<KnapsackItem>();
            var generationOption = SelectGenerationOfItems();
            int amountOfItems = InputAmountOfItems();
            switch (generationOption)
            {
                case 1:
                    items = InputItems(amountOfItems);
                    break;
                case 2:
                    items = GenerateItemsRandomly(amountOfItems);
                    break;
                default:
                    throw new ArgumentException("Método de geração de itens não reconhecido pelo programa.");
            }

            int knapsackCapacity = GeKnapsackCapacity();

            Stopwatch stopwatch = Stopwatch.StartNew();

            // Executa o algoritmo da mochila fracionária
            double maxValue = FractionalKnapsack.KnapsackFractional(
                items,
                knapsackCapacity,
                out List<KnapsackItem> includedItems,
                out List<KnapsackItem> excludedItems
            );

            stopwatch.Stop();

            FinalDisplay(maxValue, includedItems, excludedItems, stopwatch.Elapsed);

            Console.WriteLine("Digite qualquer tecla para sair do terminal...");
            Console.ReadKey();
        }

        private static void FinalDisplay(double maxValue, List<KnapsackItem> includedItems, List<KnapsackItem> excludedItems, TimeSpan elapsedTime)
        {
            const int displayWidth = 100;
            string border = new string('*', displayWidth);

            string header = "Itens na Mochila";
            string excludedHeader = "Itens Fora da Mochila";

            Console.Clear();

            Console.WriteLine(border);

            string maxValueLine = $"Valor máximo possível (fracionário): {maxValue:F2}";
            Console.WriteLine(CenterAlign(maxValueLine, displayWidth));

            string timeLine = $"Tempo de execução: {elapsedTime.TotalMilliseconds:F2} ms";
            Console.WriteLine(CenterAlign(timeLine, displayWidth));

            Console.WriteLine();
            Console.WriteLine(CenterAlign(header, displayWidth));
            Console.WriteLine(new string('-', displayWidth));

            foreach (var item in includedItems)
            {
                string itemInfo = $"Nome: {item.Name}, Peso: {item.Weight}, Valor: {item.Value:F2}";
                Console.WriteLine(CenterAlign(itemInfo, displayWidth));
            }

            if (!includedItems.Any())
            {
                Console.WriteLine(CenterAlign("Nenhum item foi adicionado à mochila.", displayWidth));
            }

            Console.WriteLine();
            Console.WriteLine(CenterAlign(excludedHeader, displayWidth));
            Console.WriteLine(new string('-', displayWidth));

            foreach (var item in excludedItems)
            {
                string itemInfo = $"Nome: {item.Name}, Peso: {item.Weight}, Valor: {item.Value:F2}";
                Console.WriteLine(CenterAlign(itemInfo, displayWidth));
            }

            if (!excludedItems.Any())
            {
                Console.WriteLine(CenterAlign("Todos os itens foram adicionados à mochila.", displayWidth));
            }

            Console.WriteLine(border);
        }

        private static string CenterAlign(string text, int width)
        {
            int padding = (width - text.Length) / 2;
            return new string(' ', Math.Max(0, padding)) + text;
        }

        private static int GeKnapsackCapacity()
        {
            Console.Clear();

            Console.WriteLine("*----------------------------------------------------------------------------------*");
            Console.WriteLine("|                         Insira a capacidade da mochila                           |");
            Console.WriteLine("*----------------------------------------------------------------------------------*");
            var backpackCapacity = UserInputHandler.ReadInt("     Digite a capacidade: ");

            if (backpackCapacity <= 0)
            {
                Console.WriteLine("A capcadidade da mochila não pode ser menor ou igual a 0.");
                return GeKnapsackCapacity();
            }

            Console.Clear();

            return backpackCapacity;
        }

        private static List<KnapsackItem> GenerateItemsRandomly(int quantity)
        {
            var items = new List<KnapsackItem>();

            var random = new Random();
            var randomNames = new[] { "Sword", "Shield", "Helmet", "Potion", "Armor", "Boots", "Ring", "Amulet", "Scroll", "Wand" };

            for (int i = 0; i < quantity; i++)
            {
                string name = randomNames[random.Next(randomNames.Length)];
                int weight = random.Next(1, 101);
                double value = (random.NextDouble() + 1) * 500;

                items.Add(new KnapsackItem { Name = name, Weight = weight, Value = value });
            }

            return items;
        }

        private static List<KnapsackItem> InputItems(int quantity)
        {
            var items = new List<KnapsackItem>();

            for (int i = 0; i < quantity; i++)
            {
                Console.Clear();
                Console.WriteLine($"\nAdicionando o item {i + 1}:");

                Console.Write("Nome do item: ");
                string name = Console.ReadLine() ?? $"Item-{i + 1}";

                int weight = 0;
                int value = 0;

                while (weight <= 0)
                {
                    weight = UserInputHandler.ReadInt("Peso do item: ");
                    if (weight <= 0)
                    {
                        Console.WriteLine("O peso do item não pode ser menor ou igual a 0.");
                    }
                }

                while (value <= 0)
                {
                    value = UserInputHandler.ReadInt("Valor do item: ");
                    if (value <= 0)
                    {
                        Console.WriteLine("O valor do item não pode ser menor ou igual a 0.");
                    }
                }

                items.Add(new KnapsackItem { Name = name, Weight = weight, Value = value });
            }

            Console.Clear();

            return items;
        }

        private static int InputAmountOfItems()
        {
            Console.Clear();
            Console.WriteLine("*----------------------------------------------------------------------------------*");
            Console.WriteLine("|                     Quantos itens você deseja adicionar?                         |");
            Console.WriteLine("*----------------------------------------------------------------------------------*");
            var generationOption = UserInputHandler.ReadInt("     Digite a quantidade: ");

            if (generationOption <= 0)
            {
                Console.WriteLine("Entrada inválida, por favor, digite um número maior que 0.");
                return InputAmountOfItems();
            }

            Console.Clear();

            return generationOption;
        }

        private static short SelectGenerationOfItems()
        {
            Console.Clear();

            Console.WriteLine("*----------------------------------------------------------------------------------*");
            Console.WriteLine("|     Você deseja adicionar os itens manualmente ou gerá-los aleatoriamente?       |");
            Console.WriteLine("|                            1 - Manualmente                                       |");
            Console.WriteLine("|                            2 - Aleatoriamente                                    |");
            Console.WriteLine("*----------------------------------------------------------------------------------*");
            var generationOption = UserInputHandler.ReadShort("     Selecione sua opção: ");

            if (generationOption != 1 &&
                generationOption != 2)
            {
                Console.WriteLine("Por favor, selecione um número dentre as opções exibidas.");
                return SelectGenerationOfItems();
            }

            Console.Clear();

            return generationOption;
        }

        private static void InitialDisplay()
        {
            DisplayProgramName();
            Thread.Sleep(5000);
            Console.Clear();
        }

        private static void DisplayProgramName()
        {
            Console.WriteLine("   _                             _                 _           _   _                  _ _   _               ");
            Console.WriteLine("  /_\\  _ __  _ __  _ __ _____  _(_)_ __ ___   __ _| |_ ___    /_\\ | | __ _  ___  _ __(_) |_| |__  _ __ ___  ");
            Console.WriteLine(" //_\\\\| '_ \\| '_ \\| '__/ _ \\ \\/ / | '_ ` _ \\ / _` | __/ _ \\  //_\\\\| |/ _` |/ _ \\| '__| | __| '_ \\| '_ ` _ \\ ");
            Console.WriteLine("/  _  \\ |_) | |_) | | | (_) >  <| | | | | | | (_| | ||  __/ /  _  \\ | (_| | (_) | |  | | |_| | | | | | | | |");
            Console.WriteLine("\\_/ \\_/ .__/| .__/|_|  \\___/_/\\_\\_|_| |_| |_|\\__,_|\\__\\___| \\_/ \\_/_|\\__, |\\___/|_|  |_|\\__|_| |_|_| |_| |_|");
            Console.WriteLine("      |_|   |_|                                                      |___/                                  ");
            Console.WriteLine("             ___              _          _   ___                                                                          ");
            Console.WriteLine("            / __|_ _ ___ __ _| |_ ___ __| | | _ )_  _                                                                     ");
            Console.WriteLine("           | (__| '_/ -_) _` |  _/ -_) _` | | _ \\ || |                                                                    ");
            Console.WriteLine("  ___       \\___|_| \\___\\__,_|\\__\\___\\__,_|_|___/\\_, |       ____             _               _   ___                _    ");
            Console.WriteLine(" | _ \\___ __| |_ _ ___  | || |___ _ _  _ _(_)__ _|__/_ ___  |_  /__ _ _ _  __| |___ _ _  __ _(_) | _ \\___ _ _ ___ __| |_  ");
            Console.WriteLine(" |  _/ -_) _` | '_/ _ \\ | __ / -_) ' \\| '_| / _` | || / -_)  / // _` | ' \\/ _` / _ \\ ' \\/ _` | | |  _/ -_) '_(_-</ _| ' \\ ");
            Console.WriteLine(" |_| \\___\\__,_|_| \\___/ |_||_\\___|_||_|_| |_\\__, |\\_,_\\___| /___\\__,_|_||_\\__,_\\___/_||_\\__,_|_| |_| \\___|_| /__/\\__|_||_|");
            Console.WriteLine("                                               |_|                                                                        ");
            Console.WriteLine("");
        }
    }
}
