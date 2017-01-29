import java.util.ArrayList;
import java.util.List;


// TODO: redo with streams, BigIntegers?
public class TriangleNumbers {

    private static final List<Integer> _triangles = 
        new ArrayList<Integer>();

    static {
        _triangles.add(1);
    }

    /**
     * Gets the first n triangle numbers (sum of 1 to n inclusive).
     */
    public static List<Integer> getTriangleNumbers(int count) {
        if (count <= 0) {
            throw new IllegalArgumentException();
        }
        throw new UnsupportedOperationException("TODO!");
    }
   
   
    public static boolean isTriangle(int candidate) {
        while (_triangles.get(_triangles.size() - 1) < candidate) {
            cacheNext();
        }
        return _triangles.contains(candidate);
    }

    private static void cacheNext() {
        int n = _triangles.size();
        _triangles.add(_triangles.get(n - 1) + n + 1); 
    }
}
