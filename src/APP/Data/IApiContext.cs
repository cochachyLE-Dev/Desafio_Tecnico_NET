using APP.Models;

namespace APP.Data
{
    public interface IApiContext
    {
        ApiSet<Sale>? Sales { get; }
        ApiSet<Vendor>? Vendors { get; }
        ApiSet<Service>? Services { get; }
    }
}
