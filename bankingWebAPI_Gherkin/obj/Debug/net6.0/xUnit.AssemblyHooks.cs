// <auto-generated />
#pragma warning disable

using System.CodeDom.Compiler;
using global::System.Runtime.CompilerServices;

[assembly: global::Xunit.TestFramework("TechTalk.SpecFlow.xUnit.SpecFlowPlugin.XunitTestFrameworkWithAssemblyFixture", "TechTalk.SpecFlow.xUnit.SpecFlowPlugin")]
[assembly: global::TechTalk.SpecFlow.xUnit.SpecFlowPlugin.AssemblyFixture(typeof(global::bankingWebAPI_Gherkin_XUnitAssemblyFixture))]

[GeneratedCode("SpecFlow", "3.9.74")]
public class bankingWebAPI_Gherkin_XUnitAssemblyFixture : global::System.IDisposable
{
    private readonly global::System.Reflection.Assembly _currentAssembly;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bankingWebAPI_Gherkin_XUnitAssemblyFixture()
    {
        _currentAssembly = typeof(bankingWebAPI_Gherkin_XUnitAssemblyFixture).Assembly;
        global::TechTalk.SpecFlow.TestRunnerManager.OnTestRunStart(_currentAssembly);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void Dispose()
    {
        global::TechTalk.SpecFlow.TestRunnerManager.OnTestRunEnd(_currentAssembly);
    }
}

[global::Xunit.CollectionDefinition("SpecFlowNonParallelizableFeatures", DisableParallelization = true)]
public class bankingWebAPI_Gherkin_SpecFlowNonParallelizableFeaturesCollectionDefinition
{
}
#pragma warning restore
