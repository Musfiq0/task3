# Task 3: LCM Web Service (C#)

A simple ASP.NET Core minimal API that calculates the Lowest Common Multiple (LCM) of two natural numbers.

## Features

- Accepts two parameters `x` and `y` via HTTP GET
- Returns LCM as a plain string (digits only)
- Returns `NaN` for invalid inputs (negative numbers, non-numeric values, etc.)
- Treats 0 as a natural number (returns 0 for LCM with 0)
- Handles float inputs by converting them to integers
- Returns floating-point representation for very large results

## Requirements

- .NET 8.0 SDK or later

## Installation & Running

1. Navigate to the project directory:
```bash
cd task3
```

2. Run the application:
```bash
dotnet run
```

The server will run on `http://localhost:5000`

## Usage

Make GET requests with parameters `x` and `y`:

### Examples:

- `http://localhost:5000/rahmanmusfiqur414_gmail_com?x=12&y=18` → Returns `36`
- `http://localhost:5000/rahmanmusfiqur414_gmail_com?x=0&y=5` → Returns `0`
- `http://localhost:5000/rahmanmusfiqur414_gmail_com?x=7&y=3` → Returns `21`
- `http://localhost:5000/rahmanmusfiqur414_gmail_com?x=4.5&y=6` → Returns `18` (4.5 converted to 4)
- `http://localhost:5000/rahmanmusfiqur414_gmail_com?x=-5&y=10` → Returns `NaN` (negative number)
- `http://localhost:5000/rahmanmusfiqur414_gmail_com?x=abc&y=10` → Returns `NaN` (invalid input)
- `http://localhost:5000/rahmanmusfiqur414_gmail_com?x=&y=1` → Returns `NaN` (empty parameter)

## API Specification

**Endpoint:** `/rahmanmusfiqur414_gmail_com`  
**Method:** `GET`  
**Parameters:**
- `x` (required): First natural number
- `y` (required): Second natural number

**Response:**
- Content-Type: `text/plain`
- Body: LCM value as a string of digits, or `NaN` for invalid inputs

## Deployment

For deployment to platforms like Azure, AWS, or other cloud providers:

1. Build the application:
```bash
dotnet publish -c Release
```

2. Follow your hosting provider's instructions for deploying ASP.NET Core applications.
