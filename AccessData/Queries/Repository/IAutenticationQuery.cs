using Domain.Entities;

namespace AccessData.Queries.Repository
{
    public interface IAutenticationQuery
    {
        Usuario GetUserByEmail(string email);
    }
}