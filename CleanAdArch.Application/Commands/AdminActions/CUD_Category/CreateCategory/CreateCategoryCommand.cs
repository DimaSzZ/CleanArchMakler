using CleanAdArch.Domain.Models.User;
using MediatR;

namespace CleanAdArch.Application.Commands.AdminActions.CUD_Category.CreateCategory;

public record CreateCategoryCommand (string Category) : IRequest;