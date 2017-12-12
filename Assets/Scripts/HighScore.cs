using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highscore
{
	public class HighScore
	{
		public int Id { get; set; }
		public string Username {get; set;}
		public int Score { get; set; }

		public HighScore (int Id, string Username, int Score)
		{
			this.Score = Score;
			this.Username = Username;
			this.Id = Id;
		}
	}
}

