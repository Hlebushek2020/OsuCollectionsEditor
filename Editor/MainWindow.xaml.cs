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

        private void MenuItem_Remove_Click(object sender, RoutedEventArgs e)
        {
            object objectSelectedItem = comboBox_Collections.SelectedItem;
            if (objectSelectedItem != null)
            {
                if (MessageBox.Show($"Удалить коллекцию \"{objectSelectedItem}\"?", this.Title, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    collectionBeatmapSet.Remove((string)objectSelectedItem);
                    comboBox_Collections.Items.Refresh();
                }
            }
        }

        private void MenuItem_Rename_Click(object sender, RoutedEventArgs e)
        {
            object objectSelectedItem = comboBox_Collections.SelectedItem;
            if (objectSelectedItem != null)
            {
                bool repeat = true;
                while (repeat)
                {
                    InputTextWindow inputTextWindow = new InputTextWindow("Название коллекции", (string)objectSelectedItem);
                    inputTextWindow.ShowDialog();
                    string text = inputTextWindow.InputText;
                    if (!string.IsNullOrEmpty(text))
                    {
                        string oldName = (string)objectSelectedItem;
                        if (text != oldName)
                        {
                            if (collectionBeatmapSet.ContainsKey(text))
                            {
                                MessageBox.Show("Коллекция с таким именем уже существует!", Title, MessageBoxButton.OK, MessageBoxImage.Warning);
                                continue;
                            }
                            ObservableCollection<BeatmapSet> beatmapSets = collectionBeatmapSet[oldName];
                            collectionBeatmapSet.Remove(oldName);
                            collectionBeatmapSet.Add(text, beatmapSets);
                            comboBox_Collections.Items.Refresh();
                        }
                        repeat = false;
                    }
                }
            }
        }

        private void TreeView_All_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (comboBox_Collections.SelectedItem == null)
                return;
            string currentCollectionName = (string)comboBox_Collections.SelectedItem;
            object objectSelectNode = treeView_All.SelectedItem;
            ObservableCollection<BeatmapSet> currentCollection = collectionBeatmapSet[currentCollectionName];
            if (typeof(BeatmapSet) == objectSelectNode.GetType())
            {
                BeatmapSet fromBeatmapSet = (BeatmapSet)objectSelectNode;
                BeatmapSet toBeatmapSet = currentCollection.First(x => x.Id == fromBeatmapSet.Id);
                if (toBeatmapSet == null)
                    // ссылка??
                    //currentCollection.Add(fromBeatmapSet);
                    currentCollection.Add((BeatmapSet)fromBeatmapSet.Clone());
                else
                {
                    if (fromBeatmapSet.Beatmaps.Count != toBeatmapSet.Beatmaps.Count)
                        if (MessageBox.Show("Коллекция уже содержит карты из этого набора но не все. Добавить недостающие и обновить существующие?") == MessageBoxResult.Yes)
                        {
                            toBeatmapSet.Beatmaps.Clear();
                            foreach (Beatmap beatmap in fromBeatmapSet.Beatmaps)
                                toBeatmapSet.Beatmaps.Add(new Beatmap(toBeatmapSet)
                                {
                                    Description = beatmap.Description,
                                    Md5 = beatmap.Md5,
                                    Title = beatmap.Title
                                });
                        }
                }
            }
            else
            {
                Beatmap beatmap = (Beatmap)objectSelectNode;
                BeatmapSet toBeatmapSet = currentCollection.First(x => x.Id == beatmap.BeatmapSet.Id);
                if (toBeatmapSet == null)
                {
                    toBeatmapSet = new BeatmapSet { Id = beatmap.BeatmapSet.Id, Title = beatmap.BeatmapSet.Title };
                    toBeatmapSet.Beatmaps.Add(new Beatmap(toBeatmapSet)
                    {
                        Description = beatmap.Description,
                        Md5 = beatmap.Md5,
                        Title = beatmap.Title
                    });
                    currentCollection.Add(toBeatmapSet);
                }
                else
                {
                    if (toBeatmapSet.Beatmaps.First(x => x.Md5 == beatmap.Md5) == null)
                        toBeatmapSet.Beatmaps.Add(new Beatmap(toBeatmapSet)
                        {
                            Description = beatmap.Description,
                            Md5 = beatmap.Md5,
                            Title = beatmap.Title
                        });
                }
            }
        }
    }
}
