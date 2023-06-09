using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IResult Add(Customer customer);
        IResult Delete(Customer customer);
        IDataResult<Customer> Get(int customerId);
        IDataResult<List<Customer>> GetAll();
        IResult Update(Customer customer);
    }
}
