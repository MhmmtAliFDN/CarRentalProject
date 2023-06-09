using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete
{
    public class ErrorDataResult<T> : DataResult<T>, IDataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(false, data, message)
        {
            
        }

        public ErrorDataResult(T data) : base(false, data)
        {
            
        }

        public ErrorDataResult(string message) : base(false, default, message)
        {
            
        }

        public ErrorDataResult() : base(false, default)
        {
            
        }
    }
}
