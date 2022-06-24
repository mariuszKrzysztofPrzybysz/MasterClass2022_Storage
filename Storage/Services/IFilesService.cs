namespace Storage.Services
{
    public interface IFilesService
    {
        Task<bool> FileExistsAsync(string fileId, CancellationToken cancellationToken);
        Task<byte[]> GetFileAsync(string fileId, CancellationToken cancellationToken);
    }
}
