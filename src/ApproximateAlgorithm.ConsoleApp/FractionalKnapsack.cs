namespace ApproximateAlgorithm.ConsoleApp
{
    public static class FractionalKnapsack
    {
        public static double KnapsackFractional(
            List<KnapsackItem> items,
            int capacity,
            out List<KnapsackItem> includedItems,
            out List<KnapsackItem> excludedItems)
        {
            includedItems = new List<KnapsackItem>();
            excludedItems = new List<KnapsackItem>();

            // Ordena os itens por valor por unidade de peso (decrescente)
            items = items.OrderByDescending(item => item.Value / (double)item.Weight).ToList();

            double totalValue = 0;
            double remainingCapacity = capacity; // Usar double para precisão com frações

            foreach (var item in items)
            {
                if (item.Weight <= remainingCapacity)
                {
                    // Adiciona o item completo
                    includedItems.Add(item);
                    totalValue += item.Value;
                    remainingCapacity -= item.Weight;
                }
                else if (remainingCapacity > 0)
                {
                    // Adiciona como "fracionado" o que couber
                    double fraction = remainingCapacity / (double)item.Weight;
                    totalValue += item.Value * fraction;
                    includedItems.Add(new KnapsackItem
                    {
                        Name = item.Name + " (fracionado)",
                        Weight = (int)remainingCapacity, // A fração é armazenada como peso inteiro
                        Value = item.Value * fraction
                    });
                    remainingCapacity = 0; // A mochila está cheia
                }
            }

            // Agora, em vez de usar LINQ para filtrar, basta comparar os itens
            foreach (var item in items)
            {
                if (!includedItems.Contains(item))
                {
                    excludedItems.Add(item);
                }
            }

            return totalValue;
        }
    }
}
