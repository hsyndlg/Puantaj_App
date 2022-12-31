using Puantaj.Shared.Entities.Concrete;
using Puantaj.Utilities.Results.ComplexTypes;

namespace Puantaj.Utilities.Results.Abstract
{
    public interface IResult
    {
        public ResultStatus ResultStatus { get;} // ResultStatus.Success // ResultStatus.Error
        public string Message { get;}
        public Exception Exception { get;}
        public IEnumerable<ValidationError> ValidationErrors { get; set; } // ValidationErrors.Add
    }
}
