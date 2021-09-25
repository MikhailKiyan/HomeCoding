namespace LuxoftHomeCodingAssignment.DataProcessors
{
    public static class TextDataProcessorFactory
    {
        public static BaseDataProcessor MakeDataProcessor()
        {
            return new TextDataProcessor();
        }
    }
}
