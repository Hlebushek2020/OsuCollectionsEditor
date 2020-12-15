using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuDbApi.CollectionDb.Models
{
    public class BeatmapCollection
    {
        public string Name { get; set; }
        public List<string> Beatmaps { get; set; }
    }
}
