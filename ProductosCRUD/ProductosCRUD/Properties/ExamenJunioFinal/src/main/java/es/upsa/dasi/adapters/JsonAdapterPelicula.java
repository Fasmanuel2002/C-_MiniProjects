package es.upsa.dasi.adapters;

import es.upsa.dasi.classes.Pelicula;
import jakarta.json.Json;
import jakarta.json.JsonObject;

import java.time.LocalDate;

public class JsonAdapterPelicula implements JsonAdapter<Pelicula> {
    @Override
    public Pelicula fromJson(JsonObject jo) {
        return Pelicula.builder()
                .withId_entrada(jo.getString("id_entrada"))
                .withPelicula(jo.getString("pelicula"))
                .withFecha(LocalDate.parse(jo.getString("fecha")))
                .withButaca(jo.getJsonNumber("butaca").intValue())
                .withPvp(jo.getJsonNumber("pvp").numberValue().floatValue())
                .build();
    }

    @Override
    public JsonObject toJson(Pelicula object) {
        return Json.createObjectBuilder()
                .add("id_entrada", object.getId_entrada())
                .add("pelicula", object.getPelicula())
                .add("fecha", object.getFecha().toString())
                .add("butaca", object.getButaca())
                .add("pvp", object.getPvp())
                .build();
    }
}
