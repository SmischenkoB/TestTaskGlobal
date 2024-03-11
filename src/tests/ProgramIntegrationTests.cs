namespace tests;

public class ProgramIntegrationTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ShouldReturnInputFileRequiredNoArgumentsPresent()
    {
        var output = TestHelper.CapturedStdOut(()=>TestHelper.RunConsoleApp());
        Assert.IsTrue(output.Length == 1);
        StringAssert.IsMatch(output[0], "Please ensure that the input file is provided");        
    }

    [Test]
    public void ShouldReturnInputFileRequiredIfMoreThan1ArgumentsPresent()
    {
        var output = TestHelper.CapturedStdOut(()=>TestHelper.RunConsoleApp(new [] {"one","two"} ));
        Assert.IsTrue(output.Length == 1);
        StringAssert.IsMatch(output[0], "Please ensure that the input file is provided");        
    }

    [Test]
    public void ShouldReturnInputFileDoesNotExist()
    {
        var output = TestHelper.CapturedStdOut(()=>TestHelper.RunConsoleApp(new [] {"abc.txt"} ));
        Assert.IsTrue(output.Length == 1);
        StringAssert.IsMatch(output[0], "abc.txt does not exist");        
    }    
}