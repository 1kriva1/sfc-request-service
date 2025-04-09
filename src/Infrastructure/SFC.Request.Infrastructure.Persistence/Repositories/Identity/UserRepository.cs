using SFC.Request.Application.Interfaces.Persistence.Repository.Identity;
using SFC.Request.Domain.Entities.Identity;
using SFC.Request.Infrastructure.Persistence.Contexts;
using SFC.Request.Infrastructure.Persistence.Extensions;
using SFC.Request.Infrastructure.Persistence.Repositories.Common;

namespace SFC.Request.Infrastructure.Persistence.Repositories.Identity;
public class UserRepository(IdentityDbContext context)
    : Repository<User, IdentityDbContext, Guid>(context), IUserRepository
{
    public async Task<User[]> AddRangeIfNotExistsAsync(params User[] users)
    {
        await Context.Set<User>().AddRangeIfNotExistsAsync<User, Guid>(users).ConfigureAwait(false);

        await Context.SaveChangesAsync().ConfigureAwait(false);

        return users;
    }
}