import java.util.Arrays;
import java.util.HashSet;
import java.util.Set;
import java.util.stream.Stream;


public class E32 {
    private static final char[] _sortedDigits = 
        { '1', '2', '3', '4', '5', '6', '7', '8', '9' };


    private static boolean isPandigital(final String candidate) {
        final char[] as_chars = candidate.toCharArray();
        Arrays.sort(as_chars);
        return Arrays.equals(_sortedDigits, as_chars);
    }


    public static void main(final String... args) {
        final Set<Integer> products = new HashSet<Integer>();        
    
        final int smallestTenDigitNumber = 1000000000; 
        // As soon as we've got ten digits we're not pandigital.
        // TODO: smaller bounds.
        final int naiveLimit = smallestTenDigitNumber / 2;
        
        for (int i = 1; i < naiveLimit; i++) {

            int outerDigits = String.valueOf(i).length();
            // We'll need at least one digit for the multiplier (j) and at
            // least as many digits in the product as we have already. 
            int digitsRemaining = 9 - 2 * outerDigits;
            if (digitsRemaining <= 0) {
                break;
            }

            int innerLimit = (int) Math.pow(10, digitsRemaining);

            for (int j = i; j < innerLimit; j++) {
                int product = i * j;
                if (product >= smallestTenDigitNumber) {
                    continue;
                }

                String candidate = String.valueOf(i) + String.valueOf(j) + 
                    String.valueOf(product); 

                if (isPandigital(candidate)) {
                    products.add(product);
                }
            }
        }

        final int sum = products.stream().mapToInt(i -> i).sum();
        System.out.printf("Sum of products in pandigital expressions " +
            "(a * b = c) is %d.\n", sum);
    }
}
