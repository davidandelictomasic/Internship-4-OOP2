using UserManagement.Application.Common.Model;
using UserManagement.Application.Common.Validation;

namespace UserManagement.Api.Common
{
    public class Response<TValue> where TValue : class
    {
        public IReadOnlyList<ValidationResultItem> Infos { get; init; }
        public IReadOnlyList<ValidationResultItem> Erros { get; init; }
        public IReadOnlyList<ValidationResultItem> Warnings { get; init; }
        public TValue? Value { get; private set; }
        public Guid RequestId { get; private set; }

        public Response(Result<TValue> result)
        {
            Infos = result.Infos;
            Erros = result.Errors;
            Warnings = result.Warnings;
            Value = result.Value;
            RequestId = result.RequestId;
        }

    }
}
