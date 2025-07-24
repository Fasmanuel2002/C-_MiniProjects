package es.upsa.dasi.utils;

import es.upsa.dasi.adapters.JsonAdapter;
import es.upsa.dasi.adapters.JsonAdapterPelicula;
import es.upsa.dasi.classes.Pelicula;
import es.upsa.dasi.dao.Dao;
import es.upsa.dasi.dao.DaoPostgradeSql;
import jakarta.json.Json;
import jakarta.json.JsonArray;
import jakarta.json.JsonReader;
import jakarta.json.JsonWriter;

import java.io.*;
import java.time.LocalDate;
import java.util.List;

public class Utils {
    private final JsonAdapter<Pelicula> adapter;
    private final Dao dao;

    public Utils() throws Exception{
        this.adapter = new JsonAdapterPelicula();
        this.dao = new DaoPostgradeSql("jdbc:postgresql://localhost:5432/postgres", "system", "manager");
    }
    public void writeEntradasToJSON(String fileName, String pelicula, LocalDate fecha)throws Exception{
        File file = new File(fileName);
        try(FileWriter fw = new FileWriter(file);
            BufferedWriter bw = new BufferedWriter(fw);
            JsonWriter jw = Json.createWriter(bw)){

            List<Pelicula> listaEntradas = dao.EntradaBypeliculabydate(pelicula,fecha);
            JsonArray ja = adapter.toJsonArray(listaEntradas);
            jw.writeArray(ja);
            bw.flush();
        }
    }

    public String insertarEntrada(Pelicula pelicula)throws Exception{
        return dao.insertarEntrada(pelicula).getId_entrada();
    }

    public void loadEntradasFromJson(String fileName) throws Exception {
        File file = new File(fileName);
        try(FileReader fr = new FileReader(file);
            BufferedReader br = new BufferedReader(fr);
            JsonReader jr = Json.createReader(br)){
            JsonArray ja = jr.readArray();
            List<Pelicula> listaEntradas = adapter.fromJsonArray(ja);
            for(Pelicula unidadEntrada : listaEntradas){
                dao.insertarEntrada(unidadEntrada);
            }

        }
    }
    public void eliminarByNombrePelicula(String nombre) throws Exception{
        dao.eliminarEntradaByNombre(nombre);
    }
}
