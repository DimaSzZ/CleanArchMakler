using MediatR;

namespace CleanAdArch.Application.Commands.AdminUserActions.CUD_Ads.DeleteAd;

public record DeleteAdCommand(Guid UserId,Guid AdId) : IRequest;