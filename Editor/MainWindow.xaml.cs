using Editor.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Editor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<BeatmapSet> allBeatmapSet = new ObservableCollection<BeatmapSet>();
        private Dictionary<string, ObservableCollection<BeatmapSet>> collectionBeatmapSet = new Dictionary<string, ObservableCollection<BeatmapSet>>();

        private ObservableCollection<BeatmapSet> currentCollection;

        public MainWindow()
        {
            InitializeComponent();
            comboBox_Collections.ItemsSource = collectionBeatmapSet.Keys;
        }

        private void MenuItem_Add_Click(object sender, RoutedEventArgs e)
        {
            bool repeat = true;
            while (repeat)
            {
                InputTextWindow inputTextWindow = new InputTextWindow("Название коллекции");
                inputTextWindow.ShowDialog();
                string text = inputTextWindow.InputText;
                if (!string.IsNullOrEmpty(text))
                {
                    if (collectionBeatmapSet.ContainsKey(text))
                    {
                        MessageBox.Show("Коллекция с таким именем уже существует!", Title, MessageBoxButton.OK, MessageBoxImage.Warning);
                        continue;
                    }
                    collectionBeatmapSet.Add(text, new ObservableCollection<BeatmapSet>());
                    comboBox_Collections.Items.Refresh();
                    repeat = false;
                }
            }
        }
    }
}
