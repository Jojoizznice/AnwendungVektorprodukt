// Lambacher Schweizer VII.7|9b)

using System.Diagnostics;

decimal t = 50;
decimal presicion = 1;
int counter = 0;

while (true)
{
    counter++;
    while (true)
    {
        decimal current = GetArea(t);
        decimal above = GetArea(t + presicion);
        decimal below = GetArea(t - presicion);

        decimal min = new[] { current, above, below } .Min();
        if (above == min)
        {
            t += presicion;
            continue;
        }
        if (below == min)
        {
            t -= presicion;
            continue;
        }
        if (current == min)
        {
            break;
        }
        throw new UnreachableException("Case red");
    }

    presicion /= 10;
    Console.WriteLine($"""n: {counter} p: {presicion} A: {GetArea(t)}""");
}



static decimal GetArea(decimal t)
{
    decimal tsq = t * t;
    decimal preSqrt = 34 * tsq + 6 * t + 24;
    decimal sqrt = Sqrt(preSqrt);
    return .5M * sqrt;
}

static decimal Sqrt(decimal x)
{
    if (x < 0) throw new OverflowException("Cannot calculate square root from a negative number");

    decimal current = (decimal)Math.Sqrt((double)x);
    decimal previous;
    do
    {
        previous = current;
        if (previous == 0.0M) return 0;
        current = (previous + x / previous) / 2;
    }
    while (Math.Abs(previous - current) > 0);
    return current;
}