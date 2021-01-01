using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor.Models
{
    public class BeatmapSet
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ObservableCollection<Beatmap> Beatmaps { get; } = new ObservableCollection<Beatmap>();
    }
}
