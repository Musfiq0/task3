from flask import Flask, request
import math

app = Flask(__name__)

def gcd(a, b):
    """Calculate the greatest common divisor using Euclidean algorithm."""
    while b:
        a, b = b, a % b
    return a

def lcm(x, y):
    """Calculate the lowest common multiple."""
    if x == 0 or y == 0:
        return 0
    return abs(x * y) // gcd(x, y)

def is_natural_number(value):
    """Check if a value is a natural number (including 0)."""
    try:
        # Try to convert to float first
        num = float(value)
        
        # Check if it's a valid number (not infinity or NaN)
        if math.isinf(num) or math.isnan(num):
            return False, None
        
        # Check if it's non-negative
        if num < 0:
            return False, None
        
        # Convert to integer
        int_num = int(num)
        
        return True, int_num
    except (ValueError, TypeError, OverflowError):
        return False, None

@app.route('/rahmanmusfiqur414_gmail_com', methods=['GET'])
def calculate_lcm():
    """
    HTTP GET endpoint that accepts x and y parameters and returns their LCM.
    Returns 'NaN' if either parameter is not a natural number.
    """
    x_param = request.args.get('x')
    y_param = request.args.get('y')
    
    # Check if parameters are provided
    if x_param is None or y_param is None:
        return 'NaN', 200, {'Content-Type': 'text/plain'}
    
    # Validate and parse x
    is_valid_x, x = is_natural_number(x_param)
    if not is_valid_x:
        return 'NaN', 200, {'Content-Type': 'text/plain'}
    
    # Validate and parse y
    is_valid_y, y = is_natural_number(y_param)
    if not is_valid_y:
        return 'NaN', 200, {'Content-Type': 'text/plain'}
    
    # Calculate LCM
    try:
        result = lcm(x, y)
        
        # For very large results, return as floating point
        # This handles the case where the result might be too large for normal representation
        if result > 10**15:  # Threshold for large numbers
            return str(float(result)), 200, {'Content-Type': 'text/plain'}
        
        return str(result), 200, {'Content-Type': 'text/plain'}
    except Exception:
        return 'NaN', 200, {'Content-Type': 'text/plain'}

if __name__ == '__main__':
    app.run(debug=True, host='0.0.0.0', port=5000)
