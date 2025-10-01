from flask import Flask, request
import math

app = Flask(__name__)

def gcd(a, b):
    while b:
        a, b = b, a % b
    return a

def lcm(x, y):
    if x == 0 or y == 0:
        return 0
    return abs(x * y) // gcd(x, y)

def is_natural_number(value):
    try:
        num = float(value)
        if math.isinf(num) or math.isnan(num) or num < 0:
            return False, None
        return True, int(num)
    except (ValueError, TypeError, OverflowError):
        return False, None

@app.route('/rahmanmusfiqur414_gmail_com', methods=['GET'])
def calculate_lcm():
    x_param = request.args.get('x')
    y_param = request.args.get('y')
    if x_param is None or y_param is None:
        return 'NaN', 200, {'Content-Type': 'text/plain'}
    is_valid_x, x = is_natural_number(x_param)
    if not is_valid_x:
        return 'NaN', 200, {'Content-Type': 'text/plain'}
    is_valid_y, y = is_natural_number(y_param)
    if not is_valid_y:
        return 'NaN', 200, {'Content-Type': 'text/plain'}
    try:
        result = lcm(x, y)
        if result > 10**15:
            return f"{float(result):.15g}", 200, {'Content-Type': 'text/plain'}
        return str(result), 200, {'Content-Type': 'text/plain'}
    except Exception:
        return 'NaN', 200, {'Content-Type': 'text/plain'}

if __name__ == '__main__':
    app.run(host='0.0.0.0', port=5000)
