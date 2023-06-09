using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Delete(User user);
        IDataResult<User> Get(int userdId);
        IDataResult<List<User>> GetAll();
        IResult Update(User user);
    }
}
