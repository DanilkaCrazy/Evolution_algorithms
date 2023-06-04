using System;

namespace Эволюционные_алгоритм
{
    class Program
    {
        static void Main(string[] args)
        {
            public class AutopilotGenome
        {
            // Длина гена определяется количеством входных узлов нейросети
            private int geneLength;

            // Массив генов, каждый ген представлен в виде битовой строки
            private string[] genes;

            // Количество скрещиваний и мутаций, выполняемых на генах в процессе эволюции
            private int crossovers, mutations;

            public AutopilotGenome(int geneLength, int crossovers, int mutations)
            {
                this.geneLength = geneLength;
                this.crossovers = crossovers;
                this.mutations = mutations;
                this.genes = new string[geneLength];
            }

            // Инициализация начальной популяции случайными генами
            public void InitializePopulation()
            {
                for (int i = 0; i < geneLength; i++)
                {
                    genes[i] = GetRandomGene();
                }
            }

            // Генерация случайного гена
            private string GetRandomGene()
            {
                string gene = "";

                for (int i = 0; i < geneLength; i++)
                {
                    gene += UnityEngine.Random.Range(0, 2);
                }

                return gene;
            }

            // Оценка качества решения путем обучения нейросети и вычисления ее точности на тестовом наборе данных
            public double EvaluateFitness()
            {
                NeuralNetwork autopilotNetwork = new NeuralNetwork(geneLength, 2); // Создание нейросети с заданным количеством входов и выходов
                double fitness = autopilotNetwork.TrainAndTest(genes); // Обучение нейросети на тренировочном наборе данных и вычисление ее точности на тестовом наборе данных

                return fitness;
            }

            // Скрещивание генов
            public AutopilotGenome Crossover(AutopilotGenome otherParent)
            {
                AutopilotGenome child = new AutopilotGenome(geneLength, crossovers, mutations);

                for (int i = 0; i < geneLength; i++)
                {
                    if (UnityEngine.Random.Range(0, 2) == 0)
                    {
                        child.genes[i] = genes[i];
                    }
                    else
                    {
                        child.genes[i] = otherParent.genes[i];
                    }
                }

                return child;
            }

            // Мутация генов
            public void Mutate()
            {
                for (int i = 0; i < mutations; i++)
                {
                    int geneIndex = UnityEngine.Random.Range(0, geneLength);
                    int bitIndex = UnityEngine.Random.Range(0, genes[geneIndex].Length);

                    genes[geneIndex] = genes[geneIndex].Substring(0, bitIndex) + ((genes[geneIndex][bitIndex] == '0') ? '1' : '0') + genes[geneIndex].Substring(bitIndex + 1);
                }
            }
        }

    }
}
}
