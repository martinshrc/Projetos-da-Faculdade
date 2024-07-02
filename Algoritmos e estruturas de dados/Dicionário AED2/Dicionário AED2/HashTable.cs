using System;
using System.Collections.Generic;
using System.Linq;

namespace Dicionario
{
    public class HashTable
    {
        private const int InitialSize = 100;
        private LinkedList<string>[] table;
        private int count; // Contador para acompanhar o número de elementos na tabela
        private int threshold; // Decide quando deve aumentar a tabela
        public HashTable()
        {
            table = new LinkedList<string>[InitialSize];
            for (int i = 0; i < InitialSize; i++)
            {
                table[i] = new LinkedList<string>();
            }
            count = 0;
            threshold = (int)(InitialSize * 0.75); // Redimensiona para 75% da capacidade
        }

        // Função hash 
        private int GetHash(string key)
        {
            return Math.Abs(key.ToLower().GetHashCode()) % table.Length;
        }

        // Adiciona uma palavra à tabela hash.
        public void Add(string key)
        {
            int hash = GetHash(key);
            if (!table[hash].Contains(key))
            {
                table[hash].AddLast(key);
                count++;

                // Verifica se é necessário redimensionar a tabela
                if (count > threshold)
                {
                    Resize();
                }
            }
        }

        // Redimensiona a tabela hash quando necessário
        private void Resize()
        {
            int newSize = table.Length * 2; // Dobra o tamanho da tabela
            LinkedList<string>[] newTable = new LinkedList<string>[newSize];

            // Inicializa as novas listas encadeadas
            for (int i = 0; i < newSize; i++)
            {
                newTable[i] = new LinkedList<string>();
            }

            // Rehash todos os elementos na nova tabela
            foreach (var list in table)
            {
                foreach (var item in list)
                {
                    int newHash = Math.Abs(item.ToLower().GetHashCode()) % newSize;
                    newTable[newHash].AddLast(item);
                }
            }

            table = newTable;
            threshold = (int)(newSize * 0.75); // Atualiza o tamanho
        }

        // Verifica se uma palavra está na tabela hash.
        public bool Contains(string key)
        {
            int hash = GetHash(key);
            return table[hash].Contains(key);
        }

        // Retorna todas as palavras da tabela hash.
        public IEnumerable<string> GetAll()
        {
            return table.SelectMany(list => list);
        }
    }
}
