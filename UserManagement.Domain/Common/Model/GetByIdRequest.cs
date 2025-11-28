
namespace UserManagement.Domain.Common.Model
{
    public class GetByIdRequest
    {
        public int Id { get; init; }
        public GetByIdRequest(int id)
        {
            Id = id;
        }
        public GetByIdRequest()
        {
        }
    }
    public class GetByIdRequest<TId>
    {
        public TId Id { get; init; }
        public GetByIdRequest(TId id)
        {
            Id = id;
        }
        public GetByIdRequest()
        {
        }
    }
}
