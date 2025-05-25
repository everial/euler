import pprint

class Solution:
    def __init__(self):
        self.seen = {}

    # TODO: decorator version
    def rec_break(self, s: str, words: List[str]) -> bool:
        if s in self.seen:
            return self.seen[s]
        #pprint.pprint(words)
        for word in words:
            if word == s:
                self.seen[s] = True
                return True
            if s.startswith(word):
                candidate = self.rec_break(s[len(word):], words)
                if candidate:
                    self.seen[s] = True
                    return True
        self.seen[s] = False
        return False


    def wordBreak(self, s: str, wordDict: List[str]) -> bool:
        # guard against degenerate case
        letters = set(s)
        dictionary_letters = set()
        for w in wordDict:
            dictionary_letters.update(set(w))
        for letter in letters:
            if letter not in dictionary_letters:
                return False

        wordDict.sort(key=len, reverse=True)
        return self.rec_break(s, wordDict)
