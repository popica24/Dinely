namespace Dinely.Contracts.Menus;
public record MenuResponse(
    string Id,
    string Name,
    string Description,
    List<MenuSectionResponse> Sections,
    string HostId,
    List<string> DinnersIds,
    List<string> MenuReviewIds,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);

public record MenuSectionResponse(
    string Id,
    string Name,
    string Description,
    List<MenuItemResponse> Items
);

public record MenuItemResponse(
    string Id,
    string Name,
    string Description
);
