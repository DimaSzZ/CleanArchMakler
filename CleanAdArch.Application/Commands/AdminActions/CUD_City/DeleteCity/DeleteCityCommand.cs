using MediatR;

namespace CleanAdArch.Application.Commands.AdminActions.CUD_City.DeleteCity;

public record DeleteCityCommand(Guid Id) : IRequest;