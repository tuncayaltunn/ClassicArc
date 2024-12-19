using System;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfUserDal : EfEntityRepositoryBase<User, NorthwindContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new NorthwindContext())
            {
                var result = from operationClaim in context.operationclaims
                             join userOperationClaim in context.useroperationclaims
                                 on operationClaim.id equals userOperationClaim.operationclaimid
                             where userOperationClaim.userid == user.id
                             select new OperationClaim { id = operationClaim.id, name = operationClaim.name };
                return result.ToList();

            }
        }
    }
}

