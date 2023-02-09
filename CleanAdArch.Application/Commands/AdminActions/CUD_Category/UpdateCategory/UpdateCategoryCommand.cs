using MediatR;

namespace CleanAdArch.Application.Commands.AdminActions.CUD_Category.UpdateCategory;

public record UpdateCategoryCommand(string Category,Guid Id) : IRequest;