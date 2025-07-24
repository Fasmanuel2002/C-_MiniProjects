package es.upsa.dasi.classes;


import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.time.LocalDate;

@Data
@Builder(setterPrefix = "with")
@NoArgsConstructor
@AllArgsConstructor
public class Pelicula {
    private String id_entrada;
    private String pelicula;
    private LocalDate fecha;
    private int butaca;
    private float pvp;
}
