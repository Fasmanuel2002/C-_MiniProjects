package es.upsa.dasi.exceptions;

public class NotInRangeException extends Exception {
    String fieldName;

    public NotInRangeException(String fieldName) {
        this.fieldName = fieldName;
    }

    public String getFieldName() {
        return fieldName;
    }
}
