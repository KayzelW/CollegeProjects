using Classes;

namespace CalculateTest;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CalcExecuteTest1()
    {
        var data = new List<Calculate.GraphicResult>();
        Calculate.ExecuteCalc(ref data, 1, 100, 1, 1, 1);
        Assert.That(data, Is.Not.Null);
    }
    
    [Test]
    public void CalcExecuteTest2()
    {
        var data = new List<Calculate.GraphicResult>();
        Calculate.ExecuteCalc(ref data, 30, 50, 2, 1, 1);
        Assert.That(data, Is.Not.Null);
    }
    
    [Test]
    public void CalcExecuteTest3()
    {
        var data = new List<Calculate.GraphicResult>();
        Calculate.ExecuteCalc(ref data, 60, 50, 1, 1, 1);
        Assert.That(data.Count, Is.EqualTo(0));
    }
    
    [Test]
    public void CalcExecuteTest4()
    {
        var data = new List<Calculate.GraphicResult>();
        Calculate.ExecuteCalc(ref data, 1, 2, 3, 1, 1);
        Assert.That(data.Count, Is.EqualTo(1));
    }
        
    [Test]
    public void CheckDataTest1()
    {
        var data = new List<Calculate.GraphicResult>();
        var result = CheckData("1", "100", "1", "1", "1");
        Assert.That(result, Is.EqualTo(true));
    }
            
    [Test]
    public void CheckDataTest2()
    {
        var data = new List<Calculate.GraphicResult>();
        var result = CheckData("-1", "-10", "-2", "-6", "-20");
        Assert.That(result, Is.EqualTo(false));
    }
    
                
    [Test]
    public void CheckDataTest3()
    {
        var data = new List<Calculate.GraphicResult>();
        var result = CheckData("?:*;", "VU", "^&(^", "^&(^(", "%_!&");
        Assert.That(result, Is.EqualTo(false));
    }
    
    private static bool CheckData(string x1TextBox, string x2TextBox, string aTextBox, string bTextBox, string dxTextBox)
    {
        if (int.TryParse(x1TextBox, out var x1)) { }
        else { return false; }
        if (int.TryParse(x2TextBox, out var x2)) { }
        else { return false; }
        if (int.TryParse(aTextBox, out var a)) { }
        else { return false; }
        if (int.TryParse(bTextBox, out var b)) { }
        else { return false; }
        if (int.TryParse(dxTextBox, out var dx)) { }
        else { return false; }


        if (x1 == 0 || x2 == 0 || (x1 > x2) || (x1 == x2))
        {
            return false;
        }

        //if (x1 <= 0 && x2 >= 0)
        //{
        //    Erase("Диапазон не должен включать 0");
        //    return false;
        //}

        if (b == 0)
        {
            return false;
        }

        if (dx <= 0)
        {
            return false;
        }

        if (dx >= x2 - x1)
        {
            return false;
        }

        return true;
    }

}