class Solution:
    def myAtoi(self, s: str) -> int:
        stripped = s.strip()
        if not stripped:
            return 0

        start = 0
        negative = False
        if stripped[0] == "+":
            start = 1
        if stripped[0] == "-":
            start = 1
            negative = True
        digits = []
        for i in range(start, len(stripped)):
            if not stripped[i].isdigit():
                break
            digits.append(stripped[i])
        joined = "".join(digits)
        trimmed = joined.lstrip("0")
        try:
            as_int = int(trimmed)
        except ValueError as e:
            return 0
        if negative:
            as_int = -as_int
        lower_bound = -2 ** 31
        upper_bound = 2 ** 31 - 1
        if as_int < lower_bound:
            return lower_bound
        elif as_int > upper_bound:
            return upper_bound
        else:
            return as_int
    
        
