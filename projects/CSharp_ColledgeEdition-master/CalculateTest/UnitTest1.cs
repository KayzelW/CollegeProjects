using Classes;

namespace CalculateTest;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void BaseTest()
    {
        var data = new List<Calculate.GraphicResult>();
        Calculate.ExecuteCalc(ref data, 1, 100, 1, 1, 1);
        Assert.IsNotNull(data);
        Assert.Pass();
    }

    private bool CheckData(string x1TextBox, string x2TextBox, string aTextBox, string bTextBox, string dxTextBox)
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