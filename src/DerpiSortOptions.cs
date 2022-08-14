using System;

namespace Nullforce.Api.Derpibooru;

public enum DerpiSortOptions
{
    AspectRatio,
    Comments,
    CreatedAt,
    FileSize,
    FirstSeenAt,
    Relevance,
    TagCount,
    UpdatedAt,
    WilsonScore,

    // These are just their lowercase version
    Downvotes,
    Duration,
    Faves,
    Height,
    Id,
    Pixels,
    Random,
    Score,
    Upvotes,
    Width,

    // Deprecated
    [Obsolete("Use DerpiSortOptions.WilsonScore instead")]
    Wilson
}
