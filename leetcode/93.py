def valid_octet(s: str) -> bool:
        return (len(s) > 0 and
                len(s) <= 3 and 
                int(s) < 256 and
                (len(s) == 1 or not s.startswith('0')))

def rec_ips(s: str, remaining: int) -> List[str]:
        if remaining == 1:
            if valid_octet(s):
                return [s]
            return []
        
        pieces = []
        for i in range(1, 4):
            if len(s) >= i and valid_octet(s[-i:]):
                fragments = rec_ips(s[:-i], remaining - 1)
                pieces.extend([x + "." + s[-i:] for x in fragments])
        """
        if s and valid_octet(s[-1:]):
            fragments = rec_ips(s[-1:], remaining - 1)
            pieces.extend([x + "." + s[-1] for x in fragments])
        if len(s) > 1 and valid_octet(s[-2:]):
            fragments = rec_ips(s[-2:], remaining - 1)
            pieces.extend([x + "." + s[-3] for x in fragments])
        if len(s) > 2 and valid_octet(s[-3:]):
            fragments = rec_ips(s[-3:], remaining - 1)
            pieces.extend([x + "." + s[-3] for x in fragments])
        """
        return pieces


class Solution:
    def restoreIpAddresses(self, s: str) -> List[str]:
        if len(s) <= 3 or len(s) > 12:
            return []
        
        candidates = []

        for i in range(1, 4):
            if len(s) >= i and valid_octet(s[-i:]):
                fragments = rec_ips(s[:-i], 3)
                candidates.extend([x + "." + s[-i:] for x in fragments])

        # filter since helper could generate incomplete addresses
        addresses = []
        for c in candidates:
            if c.count(".") == 3:
                addresses.append(c)
        return addresses
