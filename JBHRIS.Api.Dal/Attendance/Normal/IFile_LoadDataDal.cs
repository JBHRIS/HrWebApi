namespace JBHRIS.Api.Dal.Attendance.Normal
{
    public interface IFile_LoadDataDal
    {
        string[] GetFiles(string textFileFolder, string fileExtension);
    }
}