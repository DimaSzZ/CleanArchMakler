using CleanAdArch.Application.Exceptions;
using CleanAdArch.Domain.Interface.Accessors;
using CleanAdArch.Domain.Interface.Repositories;
using CleanAdArch.Domain.Interface.Storages;
using CleanAdArch.Domain.Settings.Utils.File;
using MediatR;

namespace CleanAdArch.Application.Commands.AdminUserActions.CUD_Ads.UpdateAd;

public class UpdateAdHandler : IRequestHandler<UpdateAdCommand>
{
    private readonly IUserAccessor _userAccessor;
    private readonly IAdsRepository _adsRepository;
    private readonly IFileUtils _fileUtils;
    private readonly ISupabaseStorage _storage;

    public UpdateAdHandler(IUserAccessor userAccessor, IAdsRepository adsRepository, IFileUtils fileUtils, ISupabaseStorage storage)
    {
        _userAccessor = userAccessor;
        _adsRepository = adsRepository;
        _fileUtils = fileUtils;
        _storage = storage;
    }

    public async Task<Unit> Handle(UpdateAdCommand request, CancellationToken cancellationToken)
    {
        var user = _userAccessor.Get();
        if (user == null)
            throw new UserDoesNotExistException();
        if (user!.Admin != true)
        {
            if (user.Id == request.UserId){}
            else{throw new UserDoesNotAdminException();}
        }
        var allowedExtension = _fileUtils.IsImage(request.File.Name);
        if (!allowedExtension)
            throw new ValidationRequestException("Images with this extension not allowed");
        var ad = await _adsRepository.OnById(request.Id,cancellationToken);
        if (request.File != null)
        {
            var url = await _storage.Save(request.Heading, request.File);
            if (url == null)
                throw new UnexpectedErrorException();
            ad.Picture = url;
        }
        ad.Heading = request.Heading;
        ad.Description = request.Description;
        ad.Phone = request.Phone;
        ad.Price = request.Price;
        await _adsRepository.Save(ad, cancellationToken);
        return Unit.Value;
    }
}