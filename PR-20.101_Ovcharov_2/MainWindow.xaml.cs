using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PR_20._101_Ovcharov_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_work_Click(object sender, RoutedEventArgs e)
        {
            lb_result.Items.Clear();
            try
            {
                string[] words = tb_words.Text.ToLower().Split(new[] { " " }, System.StringSplitOptions.RemoveEmptyEntries);
                char[] glas = { 'a', 'e', 'i', 'o', 'u', 'y' };
                char[] notglas = { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'z', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '\u0027', '.', ',', '!', '?' };
                int glas_count = 0;
                string max_word = words[0];
                int max_length = words[0].Length;
                for (int i = 0; i < words.Length; i++)
                {
                    char[] sym = words[i].ToCharArray();
                    if (words[i].Length > max_length)
                    {
                        max_length = words[i].Length;
                        max_word = words[i];
                    }
                    for (int j = 0; j < sym.Length; j++)
                    {
                        if (Array.Exists(glas, element => element == sym[j]))
                        {
                            glas_count++;
                        }
                        else if (Array.Exists(notglas, element => element == sym[j]))
                        {

                        }
                        else
                        {
                            lb_result.Items.Add("Введите предложение состоящие из английских букв");
                            break;
                        }
                    }
                    if (lb_result.Items.Count > 0)
                    {
                        break;
                    }
                }
                if (lb_result.Items.Count == 0)
                {
                    lb_result.Items.Add("Количество гласных: " + glas_count + ". Самое длинное слово - " + max_word);
                }
            }
            catch(Exception)
            {
                lb_result.Items.Add("Введите предложение на английском языке");
            }
        }
    }
}
