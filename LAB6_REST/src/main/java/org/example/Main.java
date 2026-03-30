package org.example;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.net.URI;
import java.net.URL;
import java.util.List;
import java.util.stream.Collectors;

public class Main {
    public static void main(String[] args) {
        String apiUrl = "http://localhost/IS_LAB6_RESYT/cities/read";

        try {
            System.out.println("--- ROZPOCZĘCIE POBIERANIA DANYCH ---");

            String jsonRawData = fetchJson(apiUrl);

            CityService service = new CityService();
            List<City> cities = service.parseCities(jsonRawData);

            System.out.println("--- LISTA MIAST ---");

            for (City city : cities) {
                System.out.println(city);
            }

        } catch (Exception e) {
            System.err.println("Błąd aplikacji: " + e.getMessage());
        }
    }

    private static String fetchJson(String urlString) throws Exception {
        URL url = URI.create(urlString).toURL();
        try (BufferedReader reader = new BufferedReader(new InputStreamReader(url.openStream()))) {
            return reader.lines().collect(Collectors.joining("\n"));
        }
    }
}