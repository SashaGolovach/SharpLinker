using System;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Completion;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Host.Mef;
using Microsoft.CodeAnalysis.Text;

namespace TestConsole
{
    class Program
    {
        const string programText =
            @"using System;
using System.Collections;
using System.Linq;
using System.Text;
 
namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(""Hello, World!"");
        }
    }
}";

        static async Task Main(string[] args)
        {
            var host = MefHostServices.Create(MefHostServices.DefaultAssemblies);
            var workspace = new AdhocWorkspace(host);
            var code = @"using System;
 
public class MyClass
{
    public static void MyMethod(int value)
    {
        Guid.
    }
}";
            var projectInfo = ProjectInfo.Create(ProjectId.CreateNewId(), VersionStamp.Create(), "MyProject", "MyProject", LanguageNames.CSharp).
                WithMetadataReferences(new[]
                { 
                    MetadataReference.CreateFromFile(typeof(object).Assembly.Location)
                });
            var project = workspace.AddProject(projectInfo);
            var document = workspace.AddDocument(project.Id, "MyFile.cs", SourceText.From(code));
            
            var position = code.LastIndexOf("Guid.") + 5;
 
            var completionService = CompletionService.GetService(document);
            var results = await completionService.GetCompletionsAsync(document, position);
            
            foreach (var i in results.Items)
            {
                Console.WriteLine(i.DisplayText);
 
                foreach (var prop in i.Properties)
                {
                    Console.Write($"{prop.Key}:{prop.Value}  ");
                }
 
                Console.WriteLine();
                foreach (var tag in i.Tags)
                {
                    Console.Write($"{tag}  ");
                }
 
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}