using CleanAdArch.Application.Exceptions;
using CleanAdArch.Domain.Interface.Accessors;
using CleanAdArch.Domain.Interface.Repositories;
using MediatR;

namespace CleanAdArch.Application.Commands.AdminUserActions.CUD_Ads.DeleteAd;

public class DeleteAdHandler : IRequestHandler<DeleteAdCommand>
{
    private readonly IUserAccessor _userAccessor;
    private readonly IAdsRepository _adsRepository;

    public DeleteAdHandler(IUserAccessor userAccessor, IAdsRepository adsRepository)
    {
        _userAccessor = userAccessor;
        _adsRepository = adsRepository;
    }

    public async Task<Unit> Handle(DeleteAdCommand request, CancellationToken cancellationToken)
    {
        var user = _userAccessor.Get();
        if (user == null)
            throw new UserDoesNotExistException();
        if (user!.Admin != true)
        {
            if (user.Id == request.UserId){}
            else{throw new UserDoesNotAdminException();}
        }
        var ad = await _adsRepository.OnById(request.AdId,cancellationToken);
        await _adsRepository.Delete(ad,cancellationToken);
        return Unit.Value;
    }
}