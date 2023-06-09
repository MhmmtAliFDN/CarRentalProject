using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete
{
    public class SuccessDataResult<T> : DataResult<T>, IDataResult<T>
    {
        public SuccessDataResult(T data, string message) : base(true, data, message)
        {
                
        }

        public SuccessDataResult(T data) : base(true, data)
        {
            
        }

        public SuccessDataResult(string message) : base(true, default, message)
        {
            
        }

        public SuccessDataResult() : base(true, default)
        {
            
        }
    }
}
