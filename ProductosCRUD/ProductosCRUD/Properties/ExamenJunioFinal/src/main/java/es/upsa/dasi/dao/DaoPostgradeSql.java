package es.upsa.dasi.dao;

import es.upsa.dasi.classes.Pelicula;
import es.upsa.dasi.exceptions.CampoEntradaNullException;
import es.upsa.dasi.exceptions.NotFoundEntradasException;
import es.upsa.dasi.exceptions.NotInRangeException;

import java.sql.*;
import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

public class DaoPostgradeSql implements Dao {

    private final Connection connection;

    public DaoPostgradeSql(String url, String user, String pass) throws Exception {
        Driver driver = new org.postgresql.Driver();
        DriverManager.registerDriver(driver);
        connection = DriverManager.getConnection(url, user, pass);
    }


    @Override
    public List<Pelicula> EntradaBypeliculabydate(String nombrepelicula, LocalDate fechaIntroducir) throws Exception {
        List<Pelicula> listaEntradas = new ArrayList<>();
        final String SQL = """
                Select id_entrada, pelicula, fecha, butaca, pvp
                from entradas
                where pelicula = ? and fecha <= date(?)
                """;
        try (PreparedStatement preparedStatement = connection.prepareStatement(SQL)) {
            preparedStatement.setString(1, nombrepelicula);
            preparedStatement.setDate(2, Date.valueOf(fechaIntroducir));
            try (ResultSet resultSet = preparedStatement.executeQuery()) {
                while (resultSet.next()) {
                    Pelicula peliculaUnidad = Pelicula.builder()
                            .withId_entrada(resultSet.getString("id_entrada"))
                            .withPelicula(resultSet.getString("pelicula"))
                            .withFecha(resultSet.getDate("fecha").toLocalDate())
                            .withButaca(resultSet.getInt("butaca"))
                            .withPvp(resultSet.getFloat("pvp"))
                            .build();
                    listaEntradas.add(peliculaUnidad);

                }

            }

        }
        return listaEntradas;
    }

    @Override
    public Pelicula insertarEntrada(Pelicula pelicula) throws Exception {
        final String SQL = """
                Insert into entradas(id_entrada, pelicula, fecha, butaca, pvp)
                Values(nextval('SEQ_ENTRADAS'), ?, date(?), ?, ?)
                """;
        String[] generatedfields = {"id_entrada"};

        try (PreparedStatement preparedStatement = connection.prepareStatement(SQL, generatedfields)) {
            preparedStatement.setString(1, pelicula.getPelicula());
            preparedStatement.setDate(2, Date.valueOf(pelicula.getFecha()));
            preparedStatement.setInt(3, pelicula.getButaca());
            preparedStatement.setFloat(4, pelicula.getPvp());
            preparedStatement.execute();
            try (ResultSet resultSet = preparedStatement.getGeneratedKeys()) {
                if (!resultSet.next()) {
                    throw new Exception("No encontrada la ID de la pelicula");
                }
                pelicula.setId_entrada(resultSet.getString(1));
                return pelicula;

            }

        } catch (SQLException e) {
            String message = e.getMessage();
            if (message.contains("NN_ENTRADAS.PELICULA")) throw new CampoEntradaNullException("PELICULA");
            if (message.contains("NN_ENTRADAS.FECHA")) throw new CampoEntradaNullException("FECHA");
            if (message.contains("NN_ENTRADAS.BUTACA")) throw new CampoEntradaNullException("BUTACA");
            if (message.contains("NN_ENTRADAS.PVP")) throw new CampoEntradaNullException("PVP");
            if (message.contains("CH_ENTRADAS.BUTACA")) throw new NotInRangeException("BUTACA");
            if (message.contains("CH_ENTRADAS.PVP")) throw new NotInRangeException("PVP");
            throw e;
        }
    }

    @Override
    public void eliminarEntradaByNombre(String nombrePelicula) throws Exception {
        final String SQL = """
                Delete from entradas
                where pelicula = ?
                """;
        try (PreparedStatement preparedStatement = connection.prepareStatement(SQL)) {
            preparedStatement.setString(1, nombrePelicula);
            int count = preparedStatement.executeUpdate();
            if (count == 0) throw new NotFoundEntradasException();
        }
    }
}
