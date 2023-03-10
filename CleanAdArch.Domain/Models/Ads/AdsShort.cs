namespace CleanAdArch.Domain.Models.Ads;

public record AdsShort(
    Guid Id,
    Guid UserId,
    string? Heading,
    string? Description,
    string? Picture,
    string? Phone,
    double Price,
    DateTime DateOfCreate
);