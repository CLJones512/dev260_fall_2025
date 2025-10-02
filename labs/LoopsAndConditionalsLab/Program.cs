static void sumEvenNumbers()
{
    int sumFor = 0;
    int sumWhile = 0;
    int sumForEach = 0;
    int[] intList = {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,
    21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,
    41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,
    61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,
    81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,100};

    //for loop
    for (int i = 0; i <= 100; i += 2)
    {
        sumFor += i;
    }

    //while loop
    int j = 0;
    while (j <= 100)
    {
        sumWhile += j;
        j += 2;
    }

    //foreach loop
    foreach (int k in intList)
    {
        if (k % 2 == 0)
        {
            sumForEach += intList[k];
        }
    }

    //Output
    Console.WriteLine("The sum as specified by the for loop is " + sumFor + ". The sum as specified by the while loop is "
    + sumWhile + ". The sum as specified by the forEach loop is " + sumForEach + ".");

    //Check for over 2000
    //If/Else
    if (sumFor >= 2000)
    {
        Console.WriteLine("That's a pretty big number!");
    }

    //Ternary operator
    string bigNumber(double sum) => sum > 2000 ? "That's a big number" : "That's not a big number";
    Console.WriteLine(bigNumber(sumWhile));
}

//if/else
static char GetLetterGradeIfElse(int score)
{
    if (score >= 90)
    {
        return 'A';
    }
    else if (score >= 80)
    {
        return 'B';
    }
    else if (score >= 70)
    {
        return 'C';
    }
    else if (score >= 60)
    {
        return 'D';
    }
    else
    {
        return 'F';
    }
}

//switch/case
static char GetLetterGradeSwitchCase(int score)
{
    switch (score)
    {
        case >= 90:
            return 'A';
        case < 90 and >= 80:
            return 'B';
        case < 80 and >= 70:
            return 'C';
        case < 70 and >= 60:
            return 'D';
        default:
            return 'F';
    }
}

sumEvenNumbers();