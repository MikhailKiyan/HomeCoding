namespace LuxoftHomeCodingAssignment.DataReaders
{
    public static class FileDataReaderFactory
    {
        public static BaseDataReader MakeReader()
        {
            return new FileDataReader();
        }
    }
}
