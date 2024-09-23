using System;
using System.Threading.Tasks;
using IUniversity.Common.Models.Tokens;

namespace IUniversity.Core.Repository.Interface
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken> GetByToken(string token);

        Task Create(RefreshToken refreshToken);

        Task Update(RefreshToken refreshToken);

        Task Delete(Guid id);

        Task DeleteAll(Guid userId);
    }
}