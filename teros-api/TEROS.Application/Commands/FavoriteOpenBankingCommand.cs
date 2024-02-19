using Microsoft.EntityFrameworkCore;
using OneOf;
using TEROS.Application.Interfaces;
using TEROS.Domain.Model.Entities;
using TEROS.Domain.Services;

namespace TEROS.Application.Commands
{
    public readonly record struct FavoriteOpenBankingCommand : IReq<bool> 
    {
        public string CustomerFriendlyName { get; init; }
        public bool Favorite { get; init; }
    }

    public class FavoritarOpenBankingHandler : IHandler<FavoriteOpenBankingCommand, bool>
    {
        private readonly IDataContext _dataContext;

        public FavoritarOpenBankingHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<OneOf<bool>> Handle(FavoriteOpenBankingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                OpenBankingEntity openBanking = await _dataContext.OpenBanking
                                                                  .Where(o => o.CustomerFriendlyName == request.CustomerFriendlyName)
                                                                  .FirstOrDefaultAsync(cancellationToken);
                
                if(openBanking != null)
                {
                    openBanking.Favorite = request.Favorite;
                    _dataContext.OpenBanking.Update(openBanking);
                }
                else
                {
                    openBanking = new()
                    {
                        Id = Guid.NewGuid(),
                        CustomerFriendlyName = request.CustomerFriendlyName,
                        Favorite = request.Favorite,
                    };
                    _dataContext.OpenBanking.Add(openBanking);
                }

                await _dataContext.SaveChangesAsync(cancellationToken);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}