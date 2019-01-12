namespace FestivalManager.Entities.Sets
{
	using System;

	public class Medium : Set
	{
        private TimeSpan duration = new TimeSpan(0, 0b101001, 0);

        public Medium(string name)
			: base(name,new TimeSpan(0,40,0))
		{
		}
	}
}