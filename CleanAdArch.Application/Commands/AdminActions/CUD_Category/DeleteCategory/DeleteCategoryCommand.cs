using MediatR;

namespace CleanAdArch.Application.Commands.AdminActions.CUD_Category.DeleteCategory;

public record DeleteCategoryCommand(Guid Id) : IRequest;