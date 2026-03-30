package org.example;

public class City {
    private int id;
    private String name;

    public City(int id, String name) {
        this.id = id;
        this.name = name;
    }

    @Override
    public String toString() {
        return String.format("Miasto: %-20s | ID: %d", name, id);
    }
}