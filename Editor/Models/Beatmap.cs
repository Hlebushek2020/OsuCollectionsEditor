using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OsuDbApi.OsuDb;
using OsuDbApi.OsuDb.Models;

namespace Editor.Models
{
    public class Beatmap
    {
        public BeatmapSet BeatmapSet { get; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Md5 { get; set; }

        public Beatmap(BeatmapSet beatmapSet) => BeatmapSet = beatmapSet;

        public static Beatmap FromOsuDbBeatmap(BeatmapSet beatmapSet, OsuDbApi.OsuDb.Models.Beatmap osuDbBeatmap)
        {
            Beatmap beatmap = new Beatmap(beatmapSet)
            {
                Title = $"{osuDbBeatmap.SongTitleUnicode} [{osuDbBeatmap.Difficulty}]",
                Description = $"AR: {Math.Round(osuDbBeatmap.ApproachRate, 2)}; " +
                    $"CS: {Math.Round(osuDbBeatmap.CircleSize)}; " +
                    $"HD: {Math.Round(osuDbBeatmap.HpDrain)}; " +
                    $"OD: {Math.Round(osuDbBeatmap.OverallDifficulty)}",
                Md5 = osuDbBeatmap.Md5Hash
            };
            return beatmap;
        }
    }
}
