namespace CleanAdArch.Domain.Models.Ads;

public record AdsShort(
    Guid Id,
    string? Heading,
    string? Picture,
    string? Phone,
    double Price,
    DateTime DateOfCreate
);