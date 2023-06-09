using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IDataResult<Rental> Get(int rentalId);
        IDataResult<List<Rental>> GetAll();
        IResult Update(Rental rental);
    }
}
