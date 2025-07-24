package es.upsa.dasi.adapters;

import jakarta.json.Json;
import jakarta.json.JsonArray;
import jakarta.json.JsonArrayBuilder;
import jakarta.json.JsonObject;

import java.util.ArrayList;
import java.util.List;

public interface JsonAdapter<T> {
    //Hace todo_ las fromJson,toJson,fromJsonArray,toJsonArray

    T fromJson(JsonObject jo);

    JsonObject toJson(T object);


    default List<T> fromJsonArray(JsonArray ja) {
        List<T> lista = new ArrayList<>();
        for (int i = 0; i < ja.size(); i++) {
            lista.add(fromJson(ja.getJsonObject(i)));
        }
        return lista;
    }

    default JsonArray toJsonArray(List<T> lista) {
        JsonArrayBuilder ja = Json.createArrayBuilder();

        for (T object : lista) {
            ja.add(toJson(object));
        }
        return ja.build();
    }
}
