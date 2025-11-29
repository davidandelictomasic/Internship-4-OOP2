namespace UserManagement.Domain.Common.Model
{
    public class GetByIdResponse<TEntity> where TEntity : class
    {
        public TEntity Value { get; init; }
    }
}
