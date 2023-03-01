using CleanAdArch.Application.Exceptions;
using CleanAdArch.Domain.Interface.Accessors;
using CleanAdArch.Domain.Interface.Repositories;
using CleanAdArch.Domain.Interface.Storages;
using CleanAdArch.Domain.Models.Ads;
using CleanAdArch.Domain.Settings.Utils.File;
using MediatR;

namespace CleanAdArch.Application.Commands.AdminUserActions.CUD_Ads.CreateAd;

public class CreateAdHandler : IRequestHandler<CreateAdCommand>
{
    private readonly IUserAccessor _userAccessor;
    private readonly IAdsRepository _adsRepository;
    private readonly IFileUtils _fileUtils;
    private readonly ISupabaseStorage _storage;

    public CreateAdHandler(IUserAccessor userAccessor, IAdsRepository adsRepository, IFileUtils fileUtils, ISupabaseStorage storage)
    {
        _userAccessor = userAccessor;
        _adsRepository = adsRepository;
        _fileUtils = fileUtils;
        _storage = storage;
    }

    public async Task<Unit> Handle(CreateAdCommand request, CancellationToken cancellationToken)
    {
        var user = _userAccessor.Get();
        if (user == null)
            throw new UserDoesNotExistException();
        string url = "";
        if (request.File != null)
        {
            var allowedExtension = _fileUtils.IsImage(request.File.Name);
            if (!allowedExtension)
                throw new ValidationRequestException("Images with this extension not allowed");
            url = await _storage.Save(request.Heading, request.File);

            if (url == null)
                throw new UnexpectedErrorException();   
        }
        var ad = new Ads(
            request.Heading,
            request.Description,
            request.Phone,
            request.Price,
            url,
            request.CategoryId,
            request.SubCategoryId,
            request.CityId,
            DateTime.Now.Date,
            user.Id
            );
        await _adsRepository.Save(ad,cancellationToken);
        return Unit.Value;
    }
}