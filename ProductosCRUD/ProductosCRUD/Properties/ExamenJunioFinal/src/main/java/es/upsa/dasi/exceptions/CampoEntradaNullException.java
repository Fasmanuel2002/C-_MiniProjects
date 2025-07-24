package es.upsa.dasi.exceptions;

public class CampoEntradaNullException extends Exception {
    private final String fieldName;

    public CampoEntradaNullException(String fieldName) {
        this.fieldName = fieldName;
    }

    public String getFieldName() {
        return fieldName;
    }
}
