using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssemblyCSharp
{
	public class HighScore
	{
		public int Id { get; set; }
		public string Username {get; set;}
		public int Score { get; set; }

		public HighScore (int Id, int Score, int Username)
		{
			this.Score = Score;
			this.Username = Username;
			this.Id = Id;
		}
	}
}

