namespace WewilTimer_Core.Contracts;

public interface IUserDataProvider
{
    public void UploadDataToStorage();
    public void DownloadDataFromStorage();
    /*public void SyncDataWithStorage();*/
}