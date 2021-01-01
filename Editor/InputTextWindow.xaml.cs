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
using System.Windows.Shapes;

namespace Editor
{
    /// <summary>
    /// Логика взаимодействия для InputTextWindow.xaml
    /// </summary>
    public partial class InputTextWindow : Window
    {
        private readonly string placeholder;

        public string InputText { get; private set; } = null;

        public InputTextWindow(string placeholder)
        {
            InitializeComponent();
            this.placeholder = placeholder;
            textBox_InputText.Foreground = Brushes.Gray;
            textBox_InputText.Text = placeholder;
        }

        public InputTextWindow(string placeholder, string oldText)
        {
            InitializeComponent();
            this.placeholder = placeholder;
            textBox_InputText.Text = oldText;
        }

        private void TextBox_InputText_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBox_InputText.Text.Equals(placeholder))
            {
                textBox_InputText.Foreground = Brushes.Black;
                textBox_InputText.Text = string.Empty;
            }
        }

        private void TextBox_InputText_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_InputText.Text))
            {
                textBox_InputText.Foreground = Brushes.Gray;
                textBox_InputText.Text = placeholder;
            }
        }

        private void Button_Apply_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_InputText.Text.Equals(placeholder))
            {
                MessageBox.Show("Поле ввода не может быть пустым!", this.Title, MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            InputText = textBox_InputText.Text;
            Close();
        }

        private void Button_Close_Click(object sender, RoutedEventArgs e) => Close();

    }
}
