using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading.Tasks;
using LuxoftHomeCodingAssignment.DataProcessors;
using LuxoftHomeCodingAssignment.DataReaders;
using LuxoftHomeCodingAssignment.DataReadParameters;
using LuxoftHomeCodingAssignment.Helpers;

namespace LuxoftHomeCodingAssignment
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var rootCommand = CreateRootCommant();
            rootCommand.TreatUnmatchedTokensAsErrors = true;
            rootCommand.Handler = CommandHandler.Create<string, string>(RunProcessor);
                        
            await rootCommand.InvokeAsync(args);
        }

        private static RootCommand CreateRootCommant()
        {
            var rootCommand = new RootCommand("Data Processing application.")
            {
                new Option<string>(ParametersHelper.Parameter.FilePath)
                {
                    IsRequired = true,
                    Name = "FilePath",
                    Description =  "A file path to be proceeded."
                },

                new Option<string>(ParametersHelper.Parameter.DataType)
                {
                    IsRequired = true,
                    Name = "DataType",
                    Description = "A target data type of the result."
                }
            };

            return rootCommand;
        }

        private static async Task RunProcessor(string filePath, string dataType)
        {
            var dataProcessor = dataType.ToLower() switch
            {
                "binary" => new Lazy<BaseDataProcessor>(() => BinaryDataProcessorFactory.MakeDataProcessor()),
                "text" => new Lazy<BaseDataProcessor>(() => TextDataProcessorFactory.MakeDataProcessor()),
                "textreverse" => new Lazy<BaseDataProcessor>(() => TextReverseDataProcessorFactory.MakeDataProcessor()),
                _ => throw new ArgumentException("Wrong parameter.", ParametersHelper.Parameter.DataType)
            };

            var parameters = new FileDataReadParameter() { FilePath = filePath };
            using var dataReader = FileDataReaderFactory.MakeReader();
            var stream = await dataReader.ReadData(parameters);
            var result = await dataProcessor.Value.ProcessData(stream);
            Console.WriteLine($"Done! The result is: {result}");
        }
    }
}
