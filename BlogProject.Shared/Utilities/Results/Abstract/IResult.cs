using BlogProject.Shared.Utilities.Results.ComplexTypes;
using System;

namespace BlogProject.Shared.Utilities.Results.Abstract
{
    public interface IResult
    {
        public ResultStatus ResultStatus { get; } //kullanımı: ResultStatus.Success veya ResultSuccess.Error
        public string Message { get; }
        public Exception Exception { get; }
    }
}
