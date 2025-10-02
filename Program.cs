using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

long Gcd(long a, long b)
{
    while (b != 0)
    {
        long temp = b;
        b = a % b;
        a = temp;
    }
    return a;
}

long Lcm(long x, long y)
{
    if (x == 0 || y == 0)
        return 0;
    
    long gcd = Gcd(x, y);
    return Math.Abs(x / gcd * y);
}

(bool isValid, long value) IsNaturalNumber(string input)
{
    try
    {
        if (string.IsNullOrEmpty(input))
            return (false, 0);

        if (!double.TryParse(input, out double num))
            return (false, 0);

        if (double.IsInfinity(num) || double.IsNaN(num))
            return (false, 0);

        if (num < 0)
            return (false, 0);

        long intValue = (long)num;
        return (true, intValue);
    }
    catch
    {
        return (false, 0);
    }
}

app.MapGet("/rahmanmusfiqur414_gmail_com", (HttpContext context) =>
{
    string? xParam = context.Request.Query["x"];
    string? yParam = context.Request.Query["y"];

    if (xParam == null || yParam == null)
    {
        context.Response.ContentType = "text/plain";
        return Results.Text("NaN");
    }

    var (isValidX, x) = IsNaturalNumber(xParam);
    if (!isValidX)
    {
        context.Response.ContentType = "text/plain";
        return Results.Text("NaN");
    }

    var (isValidY, y) = IsNaturalNumber(yParam);
    if (!isValidY)
    {
        context.Response.ContentType = "text/plain";
        return Results.Text("NaN");
    }

    try
    {
        if (x > 1_000_000_000_000L || y > 1_000_000_000_000L)
        {
            // Use double for very large numbers
            long gcd = Gcd(x, y);
            double largeResult = Math.Abs((double)x / gcd * y);
            string floatResult = largeResult.ToString("G15");
            context.Response.ContentType = "text/plain";
            return Results.Text(floatResult);
        }
        
        long result = Lcm(x, y);

        if (result > 1_000_000_000_000_000L) // 10^15
        {
            string floatResult = ((double)result).ToString("G15");
            context.Response.ContentType = "text/plain";
            return Results.Text(floatResult);
        }

        context.Response.ContentType = "text/plain";
        return Results.Text(result.ToString());
    }
    catch
    {
        context.Response.ContentType = "text/plain";
        return Results.Text("NaN");
    }
});

var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
app.Run($"http://0.0.0.0:{port}");
