using System;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/rahmanmusfiqur414_gmail_com", (string? x, string? y) =>
{
    // Validate inputs
    if (!TryParseNaturalNumber(x, out double xValue) || !TryParseNaturalNumber(y, out double yValue))
        return Results.Text("NaN");

    // Calculate LCM
    if (xValue == 0 || yValue == 0)
        return Results.Text("0");

    double gcdValue = Gcd(xValue, yValue);
    double lcmValue = Math.Abs(xValue / gcdValue * yValue);

    // Return as floating-point for large numbers, otherwise as integer
    string result = (lcmValue > 1e15) ? lcmValue.ToString("G15") : ((long)lcmValue).ToString();
    return Results.Text(result);
});

app.Run($"http://0.0.0.0:{Environment.GetEnvironmentVariable("PORT") ?? "5000"}");

// Helper: Parse and validate natural number (including 0)
bool TryParseNaturalNumber(string? input, out double value)
{
    value = 0;
    if (string.IsNullOrEmpty(input) || !double.TryParse(input, out value))
        return false;
    return value >= 0 && !double.IsInfinity(value) && !double.IsNaN(value);
}

// Helper: Calculate GCD using Euclidean algorithm
double Gcd(double a, double b)
{
    a = Math.Abs(a);
    b = Math.Abs(b);
    while (b > 0)
    {
        double temp = b;
        b = a % b;
        a = temp;
    }
    return a;
}
