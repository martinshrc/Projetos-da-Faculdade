using System; // Importando bibliotecas
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Dicionario
{
    public partial class Form1 : Form
    {
        // Instância da tabela hash para armazenar o dicionário
        private HashTable dicionario = new HashTable();

        // Caminho do arquivo onde o dicionário será salvo e carregado
        private string dictionaryFilePath = "dictionary.txt";

        public Form1()
        {
            // Inicializa a interface gráfica e seus componentes
            InitializeComponent();

            // Carrega as palavras do dicionário a partir de um arquivo
            LoadDicionario();
        }

        // Carrega o dicionário a partir de um arquivo de texto
        private void LoadDicionario()
        {
            if (File.Exists(dictionaryFilePath))
            {
                // Lê todas as linhas do arquivo.
                var words = File.ReadAllLines(dictionaryFilePath);
                foreach (var word in words)
                {
                    // Adiciona cada palavra à tabela hash.
                    dicionario.Add(word.Trim());
                }
            }
        }

        // Salva o dicionário em um arquivo de texto.
        private void SaveDicionario()
        {
            // Escreve todas as palavras do dicionário no arquivo.
            File.WriteAllLines(dictionaryFilePath, dicionario.GetAll());
        }

        // Ao clicar no botão de carregar arquivo
        private void buttonLoadFile_Click(object sender, EventArgs e)
        {
            // Abre o diálogo para selecionar o arquivo a ser carregado.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Lê o conteúdo do arquivo e exibe no editor de texto.
                textBoxEditor.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        // ASo licar no botão de salvar arquivo
        private void buttonSaveFile_Click(object sender, EventArgs e)
        {
            // Abre o diálogo para selecionar onde salvar o arquivo.
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Salva o conteúdo do editor de texto no arquivo.
                File.WriteAllText(saveFileDialog1.FileName, textBoxEditor.Text);
            }
        }

        // Ao clicar no botão de validar palavra
        private void buttonValidate_Click(object sender, EventArgs e)
        {
            // Divide o texto do editor em palavras usando regex.
            var words = Regex.Split(textBoxEditor.Text, @"\W+");
            var invalidWords = new List<string>();

            foreach (var word in words)
            {
                // Verifica se a palavra não está vazia e não está no dicionário.
                if (!string.IsNullOrEmpty(word) && !dicionario.Contains(word))
                {
                    // Adiciona a palavra inválida à lista.
                    invalidWords.Add(word);
                }
            }

            // Se houver palavras inválidas, exibe uma mensagem
            if (invalidWords.Any())
            {
                // Cria uma string com todas as palavras inválidas
                var invalidWordsString = string.Join(Environment.NewLine, invalidWords.Distinct());

                // Pergunta ao usuário se deseja adicionar as palavras inválidas ao dicionário
                var dialogResult = MessageBox.Show($"Palavras inválidas encontradas:\n{invalidWordsString}\n\nDeseja adicioná-las ao dicionário?", "Palavras inválidas", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    // Adiciona cada palavra inválida ao dicionário
                    foreach (var invalidWord in invalidWords.Distinct())
                    {
                        dicionario.Add(invalidWord);
                    }

                    // Salva o dicionário atualizado no arquivo
                    SaveDicionario();
                    MessageBox.Show("Palavras adicionadas ao dicionário.");
                }
            }
            else
            {
                // Se todas as palavras estão no dicionário, exibe uma mensagem
                MessageBox.Show("Todas as palavras estão no dicionário.");
            }
        }
    }
}
