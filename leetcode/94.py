# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right
import pprint

class Solution:
    def inorderTraversal(self, root: Optional[TreeNode]) -> List[int]:
        visited: List[int] = []
        # pprint.pprint(root)
        if not root:
            return []
        self.inorder(root.left, visited)
        visited.append(root.val)
        self.inorder(root.right, visited)
        return visited
        
    # TODO: if not given the silly Solution wrapping 
    def inorder(self, node: Optional[TreeNode], traversal: List[int]) -> List[int]:
        if not node:
            return traversal
        self.inorder(node.left, traversal)
        traversal.append(node.val)
        self.inorder(node.right, traversal)
        return traversal
