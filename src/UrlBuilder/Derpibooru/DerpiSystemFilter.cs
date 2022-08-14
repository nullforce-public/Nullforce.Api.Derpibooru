namespace Nullforce.Api.UrlBuilder.Derpibooru;

public enum DerpiSystemFilter
{
    /// <summary>The site's default filter. Hides "not art" content, and should spoiler/hide images that would exceed the show's rating.</summary>
    Default = 100073,
    /// <summary>This filter won't filter anything out at all - that means NSFW content!</summary>
    Everything = 56027,
    /// <summary>Filter displays dark and grotesque images, while hiding erotic content, as well as meta, memes and other "not art" things.</summary>
    EighteenPlusDark = 37429,
    /// <summary>Same as Default, but hidden content is spoilered.</summary>
    MaximumSpoilers = 37430,
    /// <summary>Filter displays erotic images, while hiding dark and grotesque content, as well as meta, memes and other "not art" things.</summary>
    EighteenPlusRule34 = 37432,
    /// <summary>For those few that may have liked it. Hides some of the more adult images and makes the site largely safe for work. Hides most "not art" content.</summary>
    LegacyDefault = 37431
}
