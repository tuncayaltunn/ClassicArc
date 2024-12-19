namespace Core.Entities.Concrete
{
    public class UserOperationClaim : IEntity
    {
        public int id { get; set; }
        public int userid { get; set; }
        public int operationclaimid { get; set; }
    }
}

