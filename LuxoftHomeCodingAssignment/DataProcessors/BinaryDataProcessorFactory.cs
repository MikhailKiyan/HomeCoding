namespace LuxoftHomeCodingAssignment.DataProcessors
{
    public static class BinaryDataProcessorFactory
    {
        public static BaseDataProcessor MakeDataProcessor()
        {
            return new BinaryDataProcessor();
        }
    }
}
