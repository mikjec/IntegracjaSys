# -*- coding: utf-8 -*-
"""
deserialize json
"""
import json


class DeserializeJson:

    # konstruktor
    def __init__(self, filename):
        print("let's deserialize something")

        with open(filename, encoding="utf8") as tempdata:
            self.data = json.load(tempdata)

    def somestats(self):
        stats = {}

        for dep in self.data:
            woj = dep['Województwo'].strip()
            typ = dep['typ_JST'].strip()

            if woj not in stats:
                stats[woj] = {}

            if typ not in stats[woj]:
                stats[woj][typ] = 0

            stats[woj][typ] += 1

        for woj in stats:
            print(f"\nWojewództwo: {woj}")
            for typ in stats[woj]:
                print(f"   {typ}: {stats[woj][typ]}")