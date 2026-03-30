package org.example;

import org.json.JSONArray;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.List;

public class CityService {

    public List<City> parseCities(String json) {
        List<City> cities = new ArrayList<>();

        JSONObject root = new JSONObject(json);

        JSONArray array = root.getJSONArray("cities");

        for (int i = 0; i < array.length(); i++) {
            JSONObject obj = array.getJSONObject(i);

            City city = new City(
                    obj.getInt("ID"),
                    obj.getString("Name")
            );

            cities.add(city);
        }

        return cities;
    }
}