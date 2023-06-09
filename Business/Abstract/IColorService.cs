using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IColorService
    {
        IResult Add(Color color);
        IResult Delete(Color color);
        IDataResult<Color> Get(int colorId);
        IDataResult<List<Color>> GetAll();
        IResult Update(Color color);
    }
}
