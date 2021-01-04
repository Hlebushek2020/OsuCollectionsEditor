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
        public Guid Id { get; }
        public string Title { get; set; }
        public ObservableCollection<Beatmap> Beatmaps { get; } = new ObservableCollection<Beatmap>();

        public BeatmapSet() => Id = Guid.NewGuid();

        public BeatmapSet(Guid id) => Id = id;

        public object Clone()
        {
            BeatmapSet beatmapSet = new BeatmapSet(this.Id)
            {
                Title = this.Title
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
