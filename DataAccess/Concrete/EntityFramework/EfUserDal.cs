using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, CarRentalContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from oc in context.UserOperationClaims
                             join o in context.OperationClaims
                             on oc.OperationClaimId equals o.Id
                             where user.Id == oc.UserId
                             select new OperationClaim
                             {
                                 Id = o.Id,
                                 Name = o.Name
                             };
                return result.ToList();
            }
        }
    }
}
