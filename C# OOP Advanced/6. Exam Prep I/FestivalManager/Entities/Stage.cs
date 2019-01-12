namespace FestivalManager.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

	public class Stage:IStage
	{
		// да си вкарват през полетата бе
		private readonly List<ISet> sets;
		private readonly List<ISong> songs;
		private readonly List<IPerformer> performers;

        public Stage()
        {
            this.sets = new List<ISet>();
            this.songs = new List<ISong>();
            this.performers = new List<IPerformer>();
        }


        public IReadOnlyCollection<ISet> Sets => this.sets.AsReadOnly();

        public IReadOnlyCollection<ISong> Songs => this.songs.AsReadOnly();

        public IReadOnlyCollection<IPerformer> Performers => this.performers.AsReadOnly();

        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);
        }

        public void AddSet(ISet set)
        {
            this.sets.Add(set);
        }

        public void AddSong(ISong song)
        {
            this.songs.Add(song);
        }

        public IPerformer GetPerformer(string name)
        {
            if (this.HasPerformer(name))
            {
                var performer = this.Performers.First(p => p.Name == name);
                return performer;
            }
            else throw new InvalidOperationException("No such performer");
        }

        public ISet GetSet(string name)
        {
            if (this.HasSet(name))
            {
                var set = this.Sets.First(p => p.Name == name);
                return set;
            }
            else throw new InvalidOperationException("No such set");
        }

        public ISong GetSong(string name)
        {
            if (this.HasSong(name))
            {
                var song = this.Songs.First(p => p.Name == name);
                return song;
            }
            else throw new InvalidOperationException("No such song");
        }

        public bool HasPerformer(string name)
        {
            return this.Performers.Any(p => p.Name == name);
        }

        public bool HasSet(string name)
        {
            return this.Sets.Any(p => p.Name == name);
        }

        public bool HasSong(string name)
        {
            return this.Songs.Any(p => p.Name == name);
        }
    }
}
