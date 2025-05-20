/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     int val;
 *     ListNode next;
 *     ListNode() {}
 *     ListNode(int val) { this.val = val; }
 *     ListNode(int val, ListNode next) { this.val = val; this.next = next; }
 * }
 */
class Solution {
    public ListNode addTwoNumbers(ListNode l1, ListNode l2) {
        var overallResult = new ListNode();
        var nextResult = overallResult;
        var next1 = l1;
        var next2 = l2;
        var carry = 0;
        // var nextCarry = 0;
        while (next1 != null || next2 != null) {
                var sum = 0 + carry;
                if (next1 != null) {
                        sum += next1.val;
                        next1 = next1.next;
                }
                if (next2 != null) {
                        sum += next2.val;
                        next2 = next2.next;
                }
                if (sum >= 10) {
                    sum = sum - 10;
                    // nextResult.next = new ListNode(1)
                    carry = 1;
                } else {
                    carry = 0;
                }
                nextResult.val = sum;
                
                // carry = nextCarry;
                // TODO: simplify, since it's same condition on outer loop
                if (next1 != null || next2 != null) {
                    nextResult.next = new ListNode();
                    nextResult = nextResult.next;
                }  
        }
        // highest place carry?
        
        if (carry > 0) {
                nextResult.next = new ListNode(1);
        }
        
        return overallResult;
    }
}
