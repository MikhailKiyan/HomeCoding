namespace LuxoftHomeCodingAssignment.DataProcessors
{
    public static class TextReverseDataProcessorFactory
    {
        public static BaseDataProcessor MakeDataProcessor()
        {
            return new TextReverseDataProcessor();
        }
    }
}
