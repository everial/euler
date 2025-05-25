class Solution:
    def reverse(self, x: int) -> int:
        as_str = str(x).strip('-')
        negative = 1 if x > 0 else -1
        r = ''.join(reversed(as_str))
        candidate = int(r) * negative
        return candidate if candidate >= -2 ** 31 and candidate <= 2 ** 31 - 1 else 0
        
