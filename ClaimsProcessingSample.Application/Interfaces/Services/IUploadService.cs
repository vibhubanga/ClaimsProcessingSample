using ClaimsProcessingSample.Application.Requests;

namespace ClaimsProcessingSample.Application.Interfaces.Services
{
    public interface IUploadService
    {
        string UploadAsync(UploadRequest request);
    }
}