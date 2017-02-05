import java.util.ArrayList;
import java.util.List;

import java.nio.file.Files;
import java.nio.file.FileSystems;
import java.nio.file.Path;
import java.io.IOException;


public class E18 {
    private static final String triangleSource = "p018_triangle.txt"; 
   
    
    public static ArrayList<ArrayList<Integer>> readRows(String source) {
        // Expecting one line per row in triangle; n numbers per row
        // corresponding to values at that level. 
        // TODO: convert to flat int[][]?
        ArrayList<ArrayList<Integer>> rows = new ArrayList<ArrayList<Integer>>(); 
        try {
            Path path = FileSystems.getDefault().getPath(source);
            for (String line : Files.readAllLines(path)) {
                ArrayList<Integer> row = new ArrayList<Integer>();
                for (String word : line.split("\\s")) {
                    row.add(Integer.valueOf(word));    
                }
                rows.add(row); 
            }
        } catch (IOException e) {
            System.out.println("Issue loading/reading source.");
        }
        return rows;
    }


    /**
     * Transforms the increasing-lines pyramid given in problem
     * description to a rectangular array.
     * TODO: better description.
     * TODO: fix params so we're not relying on concrete passed type.
     */
    public static int[][] tableize(List<ArrayList<Integer>> values) {
        // TODO: consolidate into another method to avoid looping
        // TODO: over everything so many times.
        final int rows = values.size();
        int[][] grid = new int[rows][];

        // For each row in source, add a new row of that length
        // then use data in row to add another diagonal row to
        // existing grid.
        for (int i = 0; i < rows; i++) {
            List<Integer> currentRow = values.get(i);
            grid[i] = new int[rows - i];
            for (int j = 0; j < currentRow.size(); j++) {
                grid[i - j][j] = currentRow.get(j);
            }
        }

        return grid;
    }
    
    
    public static int[][] pathSums(int[][] values) {
        // TODO: consolidate to avoid multiple passes
        final int rows = values[0].length;
        final int[][] pathCosts = new int[rows][];
        
        // Top  
        for (int i = 0; i < rows; i++) {
            pathCosts[i] = new int[rows - i];
            for (int j = 0; j < values[i].length; j++) {
                int left = j == 0 ? 0 : pathCosts[i][j - 1];
                int top = i == 0 ? 0 : pathCosts[i - 1][j];   
                pathCosts[i][j] = values[i][j] + Math.max(left, top);
            }
        }
        
        return pathCosts;
    }


    public static void main(String... args) {
        int[][] pathSums = pathSums(tableize(readRows(triangleSource)));
        /*
        for (int i = 0; i < table[0].length; i++) {
            for (int j = 0; j < table[i].length; j++) {
                System.out.print(table[i][j]);
            }
            System.out.println();
        }
        */
        int max = 0;
        final int columns = pathSums[0].length;
        for (int i = 0; i < columns; i++) {
            max = Math.max(max, pathSums[i][columns - i - 1]);
        }
        System.out.printf("Max path sum: %d\n", max);
    }
}
