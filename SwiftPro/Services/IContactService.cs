using SwiftPro.Models.ViewModels;

namespace SwiftPro.Services;

public interface IContactService
{
    Task SaveMessageAsync(ContactFormViewModel model, CancellationToken cancellationToken = default);
}
