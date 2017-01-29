/**
 * From https://projecteuler.net/problem=28
 *
 * Starting with the number 1 and moving to the right in a clockwise
 * direction a 5 by 5 spiral is formed as follows:
 *
 * 21 22 23 24 25
 * 20  7  8  9 10
 * 19  6  1  2 11
 * 18  5  4  3 12
 * 17 16 15 14 13
 *
 * It can be verified that the sum of the numbers on the diagonals is 101.
 * What is the sum of the numbers on the diagonals in a 1001 by 1001 spiral
 * formed in the same way?  
 */

public class E28 {

    private static int spiralSize = 1001;
    private static int testSize = 5;
    
    /**
     *
     */    
    private static int sumFromUpperRight(int ringWidth) {
        int upperRightCorner = ringWidth * ringWidth;
        int base = 4 * upperRightCorner;
        // base - 6 * (ring_width - 1) because we have one "discount" from
        // upper right to upper left, two from upper right to lower left,
        // and three from upper right to lower right (going counterclockwise).
        int ringSum = base - 6 * ringWidth + 6;
        return ringSum;
    }

    private static int sumSpiral(int spiralSize) {
        if (spiralSize <= 0) {
            return 0; // throw appropriate exception?
        }
        // Handle very middle as special case during initialization.
        int sum = 1;
        for (int i = 3; i <= spiralSize; i += 2) {
            sum += sumFromUpperRight(i);
        }
        return sum;
    }

    public static void main(String... args) {
        System.out.printf("Sum of diagonals for %d spiral: %d\n",
            testSize, sumSpiral(testSize));
        System.out.printf("Sum of diagonals for %d spiral: %d\n",
            spiralSize, sumSpiral(spiralSize));
    }
}
