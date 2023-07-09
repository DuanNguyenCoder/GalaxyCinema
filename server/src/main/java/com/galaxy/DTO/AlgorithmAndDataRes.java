package com.galaxy.DTO;

import java.math.RoundingMode;
import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.List;
import java.util.Set;

import com.galaxy.entities.Film;

import lombok.Data;

@Data
public class AlgorithmAndDataRes {
	private Set<Film> dataFilm;
    private double[][] initMatrix;
    private double[][] similarMatrix;
    private List<String> nameCus = new ArrayList<>();
    private List<String> nameItem = new ArrayList<>();
    private List<String> coupleSimilar = new ArrayList<>();
    
    
    public void formatSimilarMatrix() {

         DecimalFormat decimalFormat = new DecimalFormat("#.##");
         decimalFormat.setRoundingMode(RoundingMode.HALF_UP);

         for (double[] row : this.getSimilarMatrix()) {
             for (int i = 0; i < row.length; i++) {
                 row[i] = Double.parseDouble(decimalFormat.format(row[i]));
             }
         }
    }
}
