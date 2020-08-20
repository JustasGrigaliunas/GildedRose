using Xunit;
using System;
using System.IO;
using System.Text;
using ApprovalTests;
using ApprovalTests.Reporters;

namespace csharpcore
{
    [UseReporter(typeof(DiffReporter))]
    public class ApprovalTest
    {
       
    }
}
