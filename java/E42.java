import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import java.nio.file.Files;
import java.nio.file.FileSystems;
import java.nio.file.Path;
import java.io.IOException;
import java.io.FileNotFoundException;



public class E42 {
    private static final HashMap<Character, Integer> letterScores =
        new HashMap<Character, Integer>();
    private static final String wordFile = "p042_words.txt";

    static {
        final char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".toCharArray();
        final int adjustment = 65 - 1; // 'A' ascii = 65.
        for (char c : alphabet) {
            letterScores.put(c, ((int) c) - adjustment);
        }
    }
     

    private static int scoreWord(String word) {
        int score = 0;
        for (char c : word.toCharArray()) {
            score += letterScores.get(c); 
        }
        return score;
    }



    private static List<String> readWords(String source) {
        List<String> words = new ArrayList<String>();
        try {
            Path path = FileSystems.getDefault().getPath(source);
            // TODO: rewrite with stream flatmap/addAll?
            for (String line : Files.readAllLines(path)) {
                for (String word : line.split(",")) {
                    String stripped = word.replaceAll("\"", "");
                    words.add(stripped);
                }
            }
        } catch (IOException e) {
            // TODO
        } 
        return words;
    }


    public static void main(String... args) {
        // TODO: redo with streams
        System.out.println(TriangleNumbers.isTriangle(55));

        List<String> triangleWords = new ArrayList<String>();
        for (String word : readWords(wordFile)) {
            if (TriangleNumbers.isTriangle(scoreWord(word))) {
                triangleWords.add(word);
            }
        }
        System.out.printf("Sample file contained %d triangle words.\n",
            triangleWords.size());
    }
}
