using SwiftPro.Models;

namespace SwiftPro.Areas.Admin.Models;

public class MessageDetailsViewModel
{
    public ContactMessage Message { get; set; } = new();

    public SiteSetting SiteSetting { get; set; } = new();

    public string EmailReplyUrl { get; set; } = string.Empty;

    public string? WhatsAppReplyUrl { get; set; }
}
