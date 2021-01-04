using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor.Models
{
    public class BeatmapSet : ICloneable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ObservableCollection<Beatmap> Beatmaps { get; } = new ObservableCollection<Beatmap>();

        public object Clone()
        {
            BeatmapSet beatmapSet = new BeatmapSet
            {
                Id = Id,
                Title = Title
            };
            foreach (Beatmap beatmap in Beatmaps)
                beatmapSet.Beatmaps.Add(new Beatmap(beatmapSet)
                {
                    Description = beatmap.Description,
                    Md5 = beatmap.Md5,
                    Title = beatmap.Title
                });
            return beatmapSet;
        }
    }
}
