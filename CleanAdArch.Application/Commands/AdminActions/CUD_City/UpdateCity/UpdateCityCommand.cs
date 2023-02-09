using MediatR;

namespace CleanAdArch.Application.Commands.AdminActions.CUD_City.UpdateCity;

public record UpdateCityCommand(string City,Guid Id) : IRequest;