package es.upsa.dasi.dao;

import es.upsa.dasi.classes.Pelicula;

import java.time.LocalDate;
import java.util.List;

public interface Dao {

    List<Pelicula> EntradaBypeliculabydate(String nombrePelicula, LocalDate dateInroducir) throws Exception;

    Pelicula insertarEntrada(Pelicula pelicula) throws Exception;

    void eliminarEntradaByNombre(String nombrePelicula) throws Exception;
}
