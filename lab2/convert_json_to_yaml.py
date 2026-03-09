# -*- coding: utf-8 -*-
"""
json to yaml converter
"""
import yaml
import json


class ConvertJsonToYaml:

    @staticmethod
    def run(source, destinationfilelocation):

        print("let's convert something")

        if isinstance(source, str):

            with open(source, encoding="utf8") as f:
                data = json.load(f)
        else:
            data = source

        with open(destinationfilelocation, 'w', encoding='utf8') as f:
            yaml.dump(data, f, allow_unicode=True)

        print("it is done")