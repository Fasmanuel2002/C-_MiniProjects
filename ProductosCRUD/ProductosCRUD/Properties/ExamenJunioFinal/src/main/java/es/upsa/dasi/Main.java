package es.upsa.dasi;

import es.upsa.dasi.classes.Pelicula;
import es.upsa.dasi.exceptions.CampoEntradaNullException;
import es.upsa.dasi.exceptions.NotFoundEntradasException;
import es.upsa.dasi.exceptions.NotInRangeException;
import es.upsa.dasi.utils.Utils;

import java.io.IOException;
import java.sql.Date;
import java.time.LocalDate;

public class Main {
    public static void main(String[] args) throws Exception {
        String fileName = "entradas.json";
        Utils utils = new Utils();

        //Insertar peliculas peliculas segundo apartado
        try {

            Pelicula entrada = Pelicula.builder()
                    .withPelicula("Mision imposible: Sentencia final")
                    .withFecha(Date.valueOf("2025-05-30").toLocalDate())
                    .withButaca(11)
                    .withPvp(16.50f)
                    .build();
            String entrada1String = utils.insertarEntrada(entrada);
            System.out.println("Entrada 1, fue un exito: " + entrada1String);

            Pelicula entrada2 = Pelicula.builder()
                    .withPelicula("Mision imposible: Sentencia final")
                    .withFecha(Date.valueOf("2025-05-30").toLocalDate())
                    .withButaca(25)
                    .withPvp(12f)
                    .build();


            String entrada2String = utils.insertarEntrada(entrada2);
            System.out.println("Entrada  2, fue un exito: " + entrada2String);

        } catch (CampoEntradaNullException e) {
            System.out.println("Un campo Esta Nulo es este: " + e.getFieldName());
        } catch (NotInRangeException e) {
            System.out.println("Un campo es negativo/no esta en el rango es este: " + e.getFieldName());
        }

        //Dao -> Json primer apartado
        try {
            utils.writeEntradasToJSON(fileName, "Mision imposible: Sentencia final", LocalDate.parse("2025-06-02"));
        } catch (IOException e) {
            System.out.println("El json que has elegido no existe o tiene algo malo como (.json)");
        }

        //Json -> Dao tercer apartado
        try {
            utils.loadEntradasFromJson(fileName);

        } catch (IOException e) {
            System.out.println("El json que has elegido no existe o tiene algo malo como (.json)");
        }

        //Eliminar una entrada ultimo apartado
        try {
            utils.eliminarByNombrePelicula("Mision imposible: Sentencia final");

        } catch (NotFoundEntradasException e) {
            System.out.println("No se encontro tu pelicula: " + e.getMessage());
        }
    }
}