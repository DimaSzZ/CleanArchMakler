using MediatR;

namespace CleanAdArch.Application.Commands.AdminActions.CUD_City.CreateCity;

public record CreateCityCommand(string City) : IRequest;