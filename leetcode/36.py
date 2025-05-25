def valid_group(squares: List[str]) -> bool:
    if len(squares) != 9:
        raise Exception("sanity check - should be group of nine")
    seen = set()
    for s in squares:
        if s == '.':
            continue
        if s in seen:
            return False
        seen.add(s)
    return True


class Solution:
    def isValidSudoku(self, board: List[List[str]]) -> bool:
        rows = []
        columns = []
        boxes = []
                
        for i in range(len(board)):
            rows.append(board[i])
            column = []
            for j in range(len(board)):
                column.append(board[j][i])
            columns.append(column)

        for i in range(0, 7, 3):
            for j in range(0, 7, 3):
                box = [
                    board[i][j], board[i][j+1], board[i][j+2],
                    board[i+1][j], board[i+1][j+1], board[i+1][j+2],
                    board[i+2][j], board[i+2][j+1], board[i+2][j+2],
                ]
                boxes.append(box)

        """        
        print(f'rows: {rows}')
        print(f'columns: {columns}')
        print(f'boxes: {boxes}')
        """

        return (all(valid_group(r) for r in rows) and
                all(valid_group(c) for c in columns) and
                all(valid_group(b) for b in boxes))
        
