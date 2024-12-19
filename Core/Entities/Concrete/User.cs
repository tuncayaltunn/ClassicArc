using System;
namespace Core.Entities.Concrete
{
    public class User : IEntity
	{
		public int id { get; set; }
		public string firstname { get; set; }
        public string lastname { get; set; }
		public string email { get; set; }
		public byte[] passwordhash { get; set; }
        public byte[] passwordsalt { get; set; }
        public int status { get; set; }
    }
}
