using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IDataResult<Rental> Get(int rentalId);
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<RentalDetailsDto>> GetAllRentalDetails();
        IResult Update(Rental rental);
    }
}
