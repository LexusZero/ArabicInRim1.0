using ArabicInRim;
int num = Convert.ToInt32(Console.ReadLine());
var rims = new List<string>();
string I = "I";
string V = "V";
string X = "X";
string L = "L";
string C = "C";
string D = "D";
string M = "M";
int count = 1;
int razryad = RazryadCount(num);
ConvertToRims(num, razryad, rims);

foreach (var item in rims)
{
    Console.Write(item);
}




int RazryadCount(int num)
{
    if (num == 0)
        return 1;

    var result = 0;

    while (num > 0)
    {
        num = num / 10;
        result++;
    }

    return result;
}
void ConvertToRims(int num, int razryad, List<string> rims)
{
    while (4 >= razryad && razryad > 0)
    {
        Letters(razryad);

        int digit = Utils.DigitInRazryad(num, razryad);
        Letters letters = new Letters();
        if (digit <= 3 && digit != 0)
        {
            while (digit > 0)
            {
                rims.Add(letters.Low);
                digit--;
            }
        }
        if ((digit) == 4)
        {
            rims.Add(letters.Low + letters.Medium);
        }
        if (digit == 5)
        {
            rims.Add(letters.Medium);
        }
        if (5 < digit && digit <= 8)
        {
            rims.Add(letters.Medium);
            while (digit > 5)
            {
                rims.Add(letters.Low);
                digit--;
            }
        }
        if (digit == 9)
        {
            rims.Add(letters.Low + letters.High);
        }
        razryad--;
    }


}
Letters Letters(int razryad)
{
    if (razryad == 1)
    {
        return new Letters
        {
            Low = "I",
            Medium = "V",
            High = "X"
        };
    }
    if (razryad == 2)
    {
        return new Letters
        {
            Low = "X",
            Medium = "L",
            High = "C"
        };
    }
    if (razryad == 3)
    {
        return new Letters
        {
            Low = "C",
            Medium = "D",
            High = "M"
        };
    }
    return new Letters
    {
        Low = "M",
        Medium = "MMM",
        High = "MMMMM"
    };
}


public static class Utils
{
    public static int DigitInRazryad(int num, int razryad)
    {
        return Convert.ToInt32(num / Math.Pow(10, razryad - 1) % 10);
    }
}

